﻿using BusinessObjects.Constants;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTOs.Request.BookingReservation;
using DTOs.Response.BookingReservation;
using System.Net;

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
        [ProducesResponseType(typeof(Result<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBookingReservationRequest request)
        {
            _logger.LogInformation("CreateBookingReservationRequest: {@Request}", request);
            Result<int> result = await _service.Create(request);
            _logger.LogInformation("CreateBookingReservationResponse: {@Result}", result);
            return StatusCode((int)result.StatusCode, result);
        }



        [HttpDelete(ApiEndPointConstant.BookingReservation.BookingReservationEndpoint)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Result<bool> result = await _service.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet(ApiEndPointConstant.BookingReservation.BookingReservationsEndpoint)]
        [ProducesResponseType(typeof(Result<ICollection<BookingReservationViewModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            Result<ICollection<BookingReservationViewModel>> result = await _service.GetAll();
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPut(ApiEndPointConstant.BookingReservation.BookingReservationEndpoint)]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookingReservationRequest request)
        {
            Result<bool> result = await _service.Update(id, request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("get-all-booking-details")]
        public async Task<IActionResult> GetAllBookingDetails()
        {
            return Ok(await _service.GetAllBookingDetails());
        }

        [HttpGet("get-all-slots-by-date")]
        public async Task<IActionResult> GetAllSlotsByDate(DateTime date)
        {
            return Ok();
        }

        [HttpGet("get-all-bookings-of-user")]
        public async Task<IActionResult> GetAllBookingsOfUser(int userId)
        {
            return Ok(await _service.GetAllBookingReservationOfUser(userId));
        }

        [HttpPost("cancel-booking/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var result = await _service.CancelBooking(bookingId);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return Ok(result);
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}
