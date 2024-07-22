using DTOs.Response.CourtSlot;

namespace DTOs.Response.Court
{
    public class CourtDetailDto
    {
        public int Id { get; set; }
        public string CourtCode { get; set; }
        public int TypeOfCourtId { get; set; }
        public string TypeOfCourtName { get; set; }
        public int BadmintonCourtId { get; set; }
        public string BadmintonCourtName { get; set; }
        public float Price { get; set; }
        public string CourtImage { get; set; }
        public ICollection<CourtSlotDto> CourtSlots { get; set; }
    }
}
