using BusinessObjects;
using Repositories;
using Services.Interface;

namespace Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly BookingDetailRepository _repository;

        public BookingDetailService()
        {
            _repository = new BookingDetailRepository();
        }

        public async Task<List<BookingDetailEntity>> GetBookingDetailsByReservationId(int bookingReservationId)
        {
            return await _repository.GetBookingDetailsByReservationId(bookingReservationId);
        }
    }
}
