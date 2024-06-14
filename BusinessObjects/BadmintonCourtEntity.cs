using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BadmintonCourtEntity
    {
        public int Id { get; set; }
        public string CourtName { get; set; }
        public int CourtNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int NumberOfCourt { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public int CourtOwnerId { get; set; }

        public ICollection<CourtImageEntity> CourtImages { get; set; }
        public ICollection<CourtEntity> Courts { get; set; }
    }

}
