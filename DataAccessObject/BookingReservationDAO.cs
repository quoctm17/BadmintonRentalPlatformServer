using BusinessObjects.Constants;
using BusinessObjects.Exceptions;
using BusinessObjects;
using DTOs.Request.CourtSlot;
using DTOs.Response.CourtSlot;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DTOs.Request.BookingReservation;
using Microsoft.EntityFrameworkCore;
using DTOs.Response.BookingReservation;
using Mapster;
using BusinessObjects.Enums;
using BusinessObjects.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessObject
{
    public class BookingReservationDAO
    {
        private readonly AppDbContext _context;
        private static BookingReservationDAO instance;

        public BookingReservationDAO()
        {
            _context = new AppDbContext();
        }

        public static BookingReservationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingReservationDAO();
                }
                return instance;
            }
        }

        public async Task<Result<bool>> Create(CreateBookingReservationRequest request)
        {
            try
            {
                BookingReservationEntity bookingReservationEntity = new BookingReservationEntity()
                {
                    BookingStatus = BookingStatusEnum.PAYING.GetDescriptionFromEnum(),
                    PaymentStatus = PaymentStatusEnum.PENDING.GetDescriptionFromEnum(),
                    UserId = request.UserId,
                    Notes = request.Notes,
                    CreateAt = DateTime.Now,
                    TotalPrice = request.TotalPrice,
                    BadmintonCourtId = request.BadmintonCourtId
                };
                await _context.BookingReservations.AddAsync(bookingReservationEntity);
                var bookingDetails = new List<BookingDetailEntity>();
                var slots = new List<CourtSlotEntity>();
                foreach (var item in request.BookingCourtSlotRequests)
                {
                    var court = await CourtDAO.Instance.GetDetail(item.CourtId);
                    var bookingDetail = new BookingDetailEntity()
                    {
                        BookingReservation = bookingReservationEntity,
                        CourtId = item.CourtId,
                        Price = 0
                    };
                    bookingDetails.Add(bookingDetail);
                    foreach (var slot in item.BookingCourtSlotRequests)
                    {
                        /*await CourtSlotDAO.Instance.AddNew(new CourtSlotEntity()
                        {
                            BookingDetail = bookingDetail,
                            StartTime = slot.StartTime,
                            EndTime = slot.EndTime,
                            DateTime = item.Date
                        });*/
                        slots.Add(new CourtSlotEntity()
                        {
                            BookingDetail = bookingDetail,
                            StartTime = slot.StartTime,
                            EndTime = slot.EndTime,
                            DateTime = item.Date
                        });
                    }
                }
                _context.ChangeTracker.Clear();
                await _context.BookingReservations.AddAsync(bookingReservationEntity);
                await _context.BookingDetails.AddRangeAsync(bookingDetails);
                await _context.CourtSlots.AddRangeAsync(slots);
                await _context.SaveChangesAsync();
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
                    Message = ex.InnerException.ToString(),
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
                bookingReservation.PaymentStatus = request.PaymentStatus.GetDescriptionFromEnum();

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
    }
}
