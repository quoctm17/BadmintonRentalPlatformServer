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

        public async Task<Result<bool>> Create(BookingReservationRequest request)
        {
            try
            {
                UserEntity user = await _context.Users
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id.Equals(request.UserId))
                    ?? throw new BadRequestException(MessageConstant.Vi.User.Fail.NotFoundUser);

                BookingReservationEntity bookingReservation = new BookingReservationEntity
                {
                    UserId = user.Id,
                    CreateAt = DateTime.Now,
                    BookingStatus = BookingStatusConstant.PAYING,
                    PaymentStatus = PaymentStatusConstant.PENDING,
                    Notes = request.Notes,
                };

                bookingReservation.BookingDetails = new List<BookingDetailEntity>();

                foreach (var courtSlotId in request.CourtSlotId)
                {
                    CourtSlotEntity courtSlot = await _context.CourtSlots
                        .AsNoTracking()
                        .SingleOrDefaultAsync(x => x.Id == courtSlotId)
                        ?? throw new Exception(MessageConstant.Vi.CourtSlot.Fail.NotFoundCourtSlot);

                    bookingReservation.BookingDetails.Add(new BookingDetailEntity
                        {
                            BookingReservation = bookingReservation,
                            CourtSlotId = courtSlotId,
                            Price = courtSlot.Price,
                        });

                    bookingReservation.TotalPrice += courtSlot.Price;
                }

                await _context.BookingReservations.AddAsync(bookingReservation);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.CourtSlot.Fail.CreateCourtSlot);
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
    }
}
