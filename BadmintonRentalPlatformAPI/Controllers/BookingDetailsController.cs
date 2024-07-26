using Microsoft.AspNetCore.Mvc;
using Services;

namespace BadmintonRentalPlatformAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookingDetailsController : ControllerBase
    {
        private readonly BookingDetailService _service;

        public BookingDetailsController()
        {
            _service = new BookingDetailService();
        }

        [HttpGet("by-reservation/{bookingReservationId}")]
        public async Task<IActionResult> GetBookingDetailsByReservationId(int bookingReservationId)
        {
            var bookingDetails = await _service.GetBookingDetailsByReservationId(bookingReservationId);
            if (bookingDetails == null)
            {
                return NotFound();
            }

            return Ok(new { statusCode = 200, message = "Success", data = bookingDetails });
        }
    }

}
