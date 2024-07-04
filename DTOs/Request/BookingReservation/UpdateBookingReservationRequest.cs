using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.BookingReservation
{
    public class UpdateBookingReservationRequest
    {
        public BookingStatusEnum BookingStatus { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
    }
}
