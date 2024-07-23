
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class CourtSlotEntity
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime DateTime { get; set; }
        public int CourtId { get; set; }
        public int BookingDetailId { get; set; }
        public virtual BookingDetailEntity BookingDetail { get; set; }

        [ForeignKey("CourtId")]
        public virtual CourtEntity CourtEntity { get; set; }
    }
}
