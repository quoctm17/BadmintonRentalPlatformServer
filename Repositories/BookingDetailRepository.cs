using BusinessObjects;
using DataAccessObject;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public async Task<List<BookingDetailEntity>> GetBookingDetailsByReservationId(int bookingReservationId)
        {
            return await BookingDetailDAO.Instance.GetBookingDetailsByReservationId(bookingReservationId);
        }
    }
}
