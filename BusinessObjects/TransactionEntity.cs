using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public float GrossAmount { get; set; }
        public string Type { get; set; }
        public DateTime CreateAt { get; set; }
        public string Status { get; set; }
        public int PaymentId { get; set; }
        public PaymentEntity Payment { get; set; }
        public int BookingReservationId { get; set; }

        [ForeignKey("BookingReservationId")]
        public BookingReservationEntity BookingReservation { get; set; }
    }
}
