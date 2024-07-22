using System.ComponentModel.DataAnnotations;
using BusinessObjects.Constants;

namespace DTOs.Request.CourtSlot;

public class BookingCourtSlotRequest
{
    [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.CourtNumberRequired)]
    public int CourtId { get; set; }
    [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.StartTimeRequired)]
    public TimeSpan StartTime { get; set; }
    [Required(ErrorMessage = MessageConstant.Vi.CourtSlot.Require.EndTimeRequired)]
    public TimeSpan EndTime { get; set; }
}