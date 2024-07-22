using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CourtSlotEntity
    {
        [Key]
        public int Id { get; set; }
        
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime DateTime { get; set; }
        public int BookingDetailId { get; set; }
        public virtual BookingDetailEntity BookingDetail { get; set; }
    }

}
