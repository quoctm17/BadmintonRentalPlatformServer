using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public BookingReservationEntity BookingReservation { get; set; }
        public decimal GrossAmount { get; set; }
        public string Type { get; set; }
        public DateTime CreateAt { get; set; }
        public string Status { get; set; }
    }

}
