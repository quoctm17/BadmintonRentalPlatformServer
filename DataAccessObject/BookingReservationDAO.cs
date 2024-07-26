using BusinessObjects.Constants;
using BusinessObjects.Exceptions;
using BusinessObjects;
using DTOs;
using System.Net;
using DTOs.Request.BookingReservation;
using Microsoft.EntityFrameworkCore;
using DTOs.Response.BookingReservation;
using Mapster;
using BusinessObjects.Enums;
using BusinessObjects.Helpers;
using Microsoft.Extensions.Logging;

namespace DataAccessObject
{
    public class BookingReservationDAO
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BookingReservationDAO> _logger; // Thêm logger
        private static BookingReservationDAO instance;

        public BookingReservationDAO(ILogger<BookingReservationDAO> logger)
        {
            _context = new AppDbContext();
            _logger = logger;
        }

        public static BookingReservationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    // Thêm logger vào instance
                    var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                    var logger = loggerFactory.CreateLogger<BookingReservationDAO>();
                    instance = new BookingReservationDAO(logger);
                }
                return instance;
            }
        }
        public async Task<Result<bool>> Create(CreateBookingReservationRequest request)
        {
            _logger.LogInformation("CreateBookingReservationRequest: {@Request}", request); // Log request
            try
            {
                var existingCourtIds = await _context.Courts.Select(c => c.Id).ToListAsync();
                foreach (var bookingCourt in request.BookingCourtSlotRequests)
                {
                    if (!existingCourtIds.Contains(bookingCourt.CourtId))
                    {
                        _logger.LogWarning("Court with ID {CourtId} does not exist.", bookingCourt.CourtId); // Log cảnh báo
                        return new Result<bool>
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Message = $"Sân với ID {bookingCourt.CourtId} không tồn tại.",
                            Data = false
                        };
                    }
                }

                BookingReservationEntity bookingReservationEntity = new BookingReservationEntity()
                {
                    BookingStatus = BookingStatusEnum.PAYING.GetDescriptionFromEnum(),
                    UserId = request.UserId,
                    Notes = request.Notes,
                    CreateAt = DateTime.Now,
                    TotalPrice = request.TotalPrice,
                    BadmintonCourtId = request.BadmintonCourtId
                };

                var bookingDetails = new List<BookingDetailEntity>();
                var slots = new List<CourtSlotEntity>();

                foreach (var item in request.BookingCourtSlotRequests)
                {
                    var court = await _context.Courts.FindAsync(item.CourtId);
                    if (court == null)
                    {
                        _logger.LogWarning("Court with ID {CourtId} does not exist.", item.CourtId); // Log cảnh báo
                        return new Result<bool>
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Message = $"Sân với ID {item.CourtId} không tồn tại.",
                            Data = false
                        };
                    }

                    var bookingDetail = new BookingDetailEntity()
                    {
                        BookingReservation = bookingReservationEntity,
                        CourtId = item.CourtId,
                        Price = 0 // Sẽ được tính sau
                    };

                    // Tính tổng số slot và giá trị
                    int totalSlots = item.BookingCourtSlotRequests.Count;
                    float pricePerSlot = court.Price; // Lấy đơn giá của slot từ Court entity

                    bookingDetail.Price = totalSlots * pricePerSlot;
                    bookingDetails.Add(bookingDetail);

                    foreach (var slot in item.BookingCourtSlotRequests)
                    {
                        // Kiểm tra điều kiện EndTime cách StartTime 30 phút
                        if ((slot.EndTime - slot.StartTime).TotalMinutes != 30)
                        {
                            _logger.LogWarning("EndTime must be 30 minutes after StartTime."); // Log cảnh báo
                            return new Result<bool>
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Message = "Thời gian kết thúc phải cách thời gian bắt đầu 30 phút.",
                                Data = false
                            };
                        }

                        // Kiểm tra xem slot đã được đặt hay chưa
                        bool isSlotBooked = await _context.CourtSlots
                            .AnyAsync(s => s.CourtId == slot.CourtId && s.DateTime.Date == item.Date.Date && s.StartTime == slot.StartTime && s.EndTime == slot.EndTime);

                        if (isSlotBooked)
                        {
                            _logger.LogWarning("Time slot from {StartTime} to {EndTime} for court ID {CourtId} on date {Date} is already booked.",
                                slot.StartTime, slot.EndTime, slot.CourtId, item.Date.ToShortDateString()); // Log cảnh báo
                            return new Result<bool>
                            {
                                StatusCode = HttpStatusCode.BadRequest,
                                Message = $"Khung giờ từ {slot.StartTime} đến {slot.EndTime} cho sân với ID {slot.CourtId} vào ngày {item.Date.ToShortDateString()} đã được đặt trước.",
                                Data = false
                            };
                        }

                        slots.Add(new CourtSlotEntity()
                        {
                            BookingDetail = bookingDetail,
                            StartTime = slot.StartTime,
                            EndTime = slot.EndTime,
                            DateTime = item.Date,
                            CourtId = item.CourtId
                        });
                    }
                }

                _context.ChangeTracker.Clear();
                await _context.BookingReservations.AddAsync(bookingReservationEntity);
                await _context.SaveChangesAsync(); // Lưu bookingReservationEntity trước

                await _context.BookingDetails.AddRangeAsync(bookingDetails);
                await _context.CourtSlots.AddRangeAsync(slots);
                await _context.Transactions.AddAsync(new TransactionEntity()
                {
                    CreateAt = DateTime.Now,
                    Status = TransactionStatusEnum.PENDING.GetDescriptionFromEnum(),
                    BookingReservationId = bookingReservationEntity.Id, // Sử dụng ID đã lưu
                    Type = TransactionTypeEnum.Income, // Default to Income
                    GrossAmount = bookingReservationEntity.TotalPrice,
                    PaymentId = request.PaymentId
                });
                await _context.SaveChangesAsync();
                _logger.LogInformation("BookingReservation created successfully."); // Log thành công
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true,
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating BookingReservation"); // Log lỗi
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }


        public async Task<Result<ICollection<BookingReservationViewModel>>> GetAll()
        {
            try
            {
                ICollection<BookingReservationEntity> bookingReservations = await _context.BookingReservations
                    .Include(x => x.BookingDetails)
                    .AsNoTracking()
                    .ToListAsync();

                return new Result<ICollection<BookingReservationViewModel>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = bookingReservations.Adapt<ICollection<BookingReservationViewModel>>(),
                };

            }
            catch (Exception ex)
            {
                return new Result<ICollection<BookingReservationViewModel>>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request)
        {
            try
            {
                BookingReservationEntity bookingReservation = await _context.BookingReservations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id))
                    ?? throw new BadRequestException(MessageConstant.Vi.BookingReservation.Fail.NotFoundBookingReservation);

                request.Adapt(bookingReservation);

                bookingReservation.BookingStatus = request.BookingStatus.GetDescriptionFromEnum();

                _context.BookingReservations.Update(bookingReservation);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;
                //_context.Entry(bookingReservation).State = EntityState.Detached;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.BookingReservation.Fail.UpdateBookingReservation);
                }

                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true,
                };

            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                BookingReservationEntity bookingReservation = await _context.BookingReservations
                    .Include(x => x.BookingDetails)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id)
                     ?? throw new Exception(MessageConstant.Vi.BookingReservation.Fail.NotFoundBookingReservation);

                _context.BookingReservations.Remove(bookingReservation);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.BookingReservation.Fail.DeleteBookingReservation);
                }

                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true,
                };

            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }

        public async Task<BookingReservationEntity?> GetDetail(int bookingId)
        {
            return await _context.BookingReservations
                .FindAsync(bookingId);
        }

        public async Task<List<BookingReservationEntity>> GetAllBookingReservationOfUser(int userId)
        {
            return await _context.BookingReservations
                .Where(booking => booking.UserId == userId)
                .Include(booking => booking.Transactions)
                    .ThenInclude(transaction => transaction.Payment)
                .ToListAsync();
        }
        public async Task<Result<bool>> CancelBooking(int bookingId)
        {
            try
            {
                var bookingReservation = await _context.BookingReservations
                    .Include(br => br.Transactions)
                    .SingleOrDefaultAsync(br => br.Id == bookingId)
                    ?? throw new BadRequestException("Booking reservation not found.");

                if (bookingReservation.BookingStatus == BookingStatusEnum.CANCELLED.GetDescriptionFromEnum() ||
                    bookingReservation.BookingStatus == BookingStatusEnum.EXPIRED.GetDescriptionFromEnum() ||
                    bookingReservation.BookingStatus == BookingStatusEnum.USED.GetDescriptionFromEnum())
                {
                    return new Result<bool>
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Cannot cancel this booking reservation.",
                        Data = false
                    };
                }

                if (bookingReservation.BookingStatus == BookingStatusEnum.PAYING.GetDescriptionFromEnum())
                {
                    bookingReservation.BookingStatus = BookingStatusEnum.CANCELLED.GetDescriptionFromEnum();
                }
                else if (bookingReservation.BookingStatus == BookingStatusEnum.BOOKED.GetDescriptionFromEnum())
                {
                    var transaction = bookingReservation.Transactions.OrderByDescending(t => t.CreateAt).FirstOrDefault();
                    if (transaction != null)
                    {
                        if (transaction.Payment.PaymentMethod == "Cash")
                        {
                            bookingReservation.BookingStatus = BookingStatusEnum.CANCELLED.GetDescriptionFromEnum();
                        }
                        else if (transaction.Payment.PaymentMethod == "Bank Transfer")
                        {
                            if (transaction.Status == TransactionStatusEnum.COMPLETE.GetDescriptionFromEnum())
                            {
                                bookingReservation.BookingStatus = BookingStatusEnum.REFUND.GetDescriptionFromEnum();
                            }
                            else
                            {
                                bookingReservation.BookingStatus = BookingStatusEnum.CANCELLED.GetDescriptionFromEnum();
                            }
                        }
                    }
                }

                _context.BookingReservations.Update(bookingReservation);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception("Failed to cancel booking reservation.");
                }

                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Data = false
                };
            }
        }



    }
}
