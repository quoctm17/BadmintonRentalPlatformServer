namespace DTOs.Response.CourtSlot;

public class CourtSlotResponse
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
}