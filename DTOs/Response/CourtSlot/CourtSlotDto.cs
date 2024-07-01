using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.CourtSlot
{
    public class CourtSlotDto
    {
        public int Id { get; set; }
        public int CourtNumberId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public float Price { get; set; }
    }
}
