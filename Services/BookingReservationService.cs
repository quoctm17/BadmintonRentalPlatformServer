using DataAccessObject;
using DTOs.Request.BookingReservation;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingReservationService : IBookingReservationService
    {
        public BookingReservationService() { }

        public Task<Result<bool>> Create(BookingReservationRequest request) => BookingReservationDAO.Instance.Create(request);
    }
}
