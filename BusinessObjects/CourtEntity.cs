using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CourtEntity
    {
        public int Id { get; set; }
        public string CourtCode { get; set; }

        public int TypeOfCourtId { get; set; }
        public TypeOfCourtEntity TypeOfCourt { get; set; }

        public int BadmintonCourtId { get; set; }
        public BadmintonCourtEntity BadmintonCourt { get; set; }

        public ICollection<CourtSlotEntity> CourtSlots { get; set; }
    }

}
