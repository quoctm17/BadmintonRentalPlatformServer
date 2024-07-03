using BusinessObjects.Constants;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTOs.Request.BookingReservation;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class BookingReservationController : BaseController<BookingReservationController>
    {
        private readonly IBookingReservationService _service;

        public BookingReservationController(ILogger<BookingReservationController> logger, IBookingReservationService service) : base(logger)
        {
            _service = service;
        }

        [HttpPost(ApiEndPointConstant.BookingReservation.BookingReservationsEndpoint)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] BookingReservationRequest request)
        {
            Result<bool> result = await _service.Create(request);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
