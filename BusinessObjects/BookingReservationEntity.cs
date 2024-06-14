using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessObjects
{
    public class BookingReservationEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTime CreateAt { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; }

        public int PaymentId { get; set; }
        public PaymentEntity Payment { get; set; }

        public ICollection<TransactionEntity> Transactions { get; set; }
        public ICollection<BookingDetailEntity> BookingDetails { get; set; }
    }

}
