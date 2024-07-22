using BusinessObjects;
using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Request.Court;
using DTOs.Request.CourtSlot;

namespace DTOs.Request.BookingReservation
{
    public class CreateBookingReservationRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.BookingReservation.Require.UserRequired)]
        public int UserId { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BookingReservation.Require.NotesRequired)]
        public string Notes { get; set; }
        public int BadmintonCourtId { get; set; }
        public int TotalPrice { get; set; }
        public List<BookingCourtRequest> BookingCourtSlotRequests { get; set; }
    }
}
