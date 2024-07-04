using DTOs.Response.BookingDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.BookingReservation
{
    public class BookingReservationViewModel : BookingReservationDto
    {
        public ICollection<BookingDetailDto> BookingDetails { get; set; }
    }
}
