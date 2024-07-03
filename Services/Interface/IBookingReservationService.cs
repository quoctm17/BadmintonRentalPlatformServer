using DataAccessObject;
using DTOs.Request.BookingReservation;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IBookingReservationService
    {
        Task<Result<bool>> Create(BookingReservationRequest request);
    }
}
