using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class BookingDetailEntity
    {
        [Key]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public BookingReservationEntity BookingReservation { get; set; }
        public int CourtId { get; set; }
        public virtual CourtEntity CourtEntity { get; set; }
        public float Price { get; set; }
        public ICollection<CourtSlotEntity> CourtSlots { get; set; }
    }

}
