using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.BookingReservation
{
    public class BookingReservationDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public string BookingStatus { get; set; }
        public string PaymentStatus { get; set; }
        public float TotalPrice { get; set; }
        public string Notes { get; set; }
    }
}
