using DataAccessObject;
using DTOs;
using DTOs.Request.BookingReservation;
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
        public BookingReservationRepository() { }

        public Task<Result<bool>> Create(BookingReservationRequest request) => BookingReservationDAO.Instance.Create(request);
    }
}
