using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookingDetailEntity
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public BookingReservationEntity BookingReservation { get; set; }

        public int CourtSlotId { get; set; }
        public CourtSlotEntity CourtSlot { get; set; }
        public decimal Price { get; set; }
    }

}
