using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Response.BookingDetail
{
    public class BookingDetailDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int CourtSlotId { get; set; }
        public float Price { get; set; }
    }
}
