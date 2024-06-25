using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CourtSlotEntity
    {
        public int Id { get; set; }

        public int CourtNumberId { get; set; }
        public CourtEntity Court { get; set; }
        
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public float Price { get; set; }

        public ICollection<BookingDetailEntity> BookingDetails { get; set; }
    }

}
