namespace BusinessObjects
{
    public class CourtImageEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public bool IsMainCarousel { get; set; }
        public bool IsBackground { get; set; }
        public int BadmintonCourtId { get; set; }
        public BadmintonCourtEntity BadmintonCourt { get; set; }
    }

}
