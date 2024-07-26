using BusinessObjects;

namespace Repositories.Interface
{
    public interface IBookingDetailRepository
    {
        Task<List<BookingDetailEntity>> GetBookingDetailsByReservationId(int bookingReservationId);
    }
}
