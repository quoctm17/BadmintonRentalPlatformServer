
namespace DTOs.Response.CourtSlot
{
    public class CourtSlotTimeDto
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime DateTime { get; set; }
        public int BookingDetailId { get; set; }
        public int CourtId { get; set; }
    }

}
