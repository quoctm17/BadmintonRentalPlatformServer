using DTOs.Response.CourtSlot;

namespace DTOs.Response.BookingDetail
{
    public class BookingDetailTimeDto
    {
        public int Id { get; set; }
        public int CourtId { get; set; }
        public int BookingId { get; set; }
        public decimal Price { get; set; }
        public List<CourtSlotDto> CourtSlots { get; set; }
    }

}
