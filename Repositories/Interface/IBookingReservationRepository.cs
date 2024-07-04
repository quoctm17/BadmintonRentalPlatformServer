using DTOs;
using DTOs.Request.BookingReservation;
using DTOs.Response.BookingReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IBookingReservationRepository
    {
        Task<Result<bool>> Create(CreateBookingReservationRequest request);
        Task<Result<bool>> Delete(int id);
        Task<Result<ICollection<BookingReservationViewModel>>> GetAll();
        Task<Result<bool>> Update(int id, UpdateBookingReservationRequest request);
    }

}
