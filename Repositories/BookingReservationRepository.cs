using Azure.Core;
using DataAccessObject;
using DTOs;
using DTOs.Request.BookingReservation;
using DTOs.Response.BookingReservation;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        private readonly BookingReservationDAO bookingReservationDAO = new BookingReservationDAO();
        public BookingReservationRepository() { }

        public Task<Result<bool>> Create(CreateBookingReservationRequest request) => bookingReservationDAO.Create(request);
        public Task<Result<bool>> Delete(int id) => bookingReservationDAO.Delete(id);
        public Task<Result<ICollection<BookingReservationViewModel>>> GetAll() => bookingReservationDAO.GetAll();
        public Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request) => bookingReservationDAO.Update(id, request);
    }
}
