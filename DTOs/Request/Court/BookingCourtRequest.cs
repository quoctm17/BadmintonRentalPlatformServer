using DTOs.Request.CourtSlot;

namespace DTOs.Request.Court;

public class BookingCourtRequest
{
    public int CourtId { get; set; }
    public DateTime Date { get; set; }
    public List<BookingCourtSlotRequest> BookingCourtSlotRequests { get; set; }
}