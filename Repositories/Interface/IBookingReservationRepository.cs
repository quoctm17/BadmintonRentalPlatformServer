using DTOs;
using DTOs.Request.BookingReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IBookingReservationRepository
    {
        Task<Result<bool>> Create(BookingReservationRequest request);
    }
}
