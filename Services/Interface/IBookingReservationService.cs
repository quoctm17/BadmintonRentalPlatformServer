using DTOs.Request.BookingReservation;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DTOs.Response.BookingReservation;

namespace Services.Interface
{
    public interface IBookingReservationService
    {
        Task<Result<bool>> Create(CreateBookingReservationRequest request);
        Task<Result<bool>> Delete(int id);
        Task<Result<ICollection<BookingReservationViewModel>>> GetAll();
        Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request);
        public Task<Result<List<BookingDetailEntity>>> GetAllBookingDetails();
        public Task<Result<BookingReservationEntity?>> GetDetail(int bookingId);
        public Task<Result<List<BookingReservationEntity>>> GetAllBookingReservationOfUser(int userId);
        Task<Result<bool>> CancelBooking(int bookingId);
    }
}
