using BusinessObjects;
using BusinessObjects.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Request.BookingReservation
{
    public class CreateBookingReservationRequest
    {
        [Required(ErrorMessage = MessageConstant.Vi.BookingReservation.Require.UserRequired)]
        public int UserId { get; set; }
        [Required(ErrorMessage = MessageConstant.Vi.BookingReservation.Require.NotesRequired)]
        public string Notes { get; set; }
        public List<int> CourtSlotId { get; set; }
    }
}
