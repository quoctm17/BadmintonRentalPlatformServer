﻿using BusinessObjects.Constants;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTOs.Response.CourtSlot;
using DTOs.Request.CourtSlot;
using Microsoft.AspNetCore.Authorization;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class CourtSlotController : BaseController<CourtSlotController>
    {
        private readonly ICourtSlotService _service;

        public CourtSlotController(ILogger<CourtSlotController> logger, ICourtSlotService service) : base(logger)
        {
            _service = service;
        }

        [HttpPost(ApiEndPointConstant.CourtSlot.CourtSlotsEndpoint)]
        [ProducesResponseType(typeof(Result<CourtSlotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CourtSlotRequest request)
        {
            Result<CourtSlotDto> result = await _service.Create(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("create-time-span")]
        public async Task<IActionResult> CreateTimeSpan()
        {
            return Ok(new TimeSpan(2, 30,0));
        }

        [HttpGet("get-all-court-slots")]
        public async Task<IActionResult> GetAllCourtSlots()
        {
            return Ok(await _service.GetAllCourtSlots());
        }

        [HttpGet("get-all-slot-by-date-and-badminton-court")]
        public async Task<IActionResult> GetAllCourtSlotsByDateAndBadmintonCourt(int badmintonCourtId, DateTime date)
        {
            var result = await _service.GetAllCourtSlotsByDateAndBadmintonCourt(badmintonCourtId, date);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("check-in")]
        public async Task<IActionResult> CheckinForUser(int courtSlotId)
        {
            var result = await _service.CheckInSlotForUser(courtSlotId);
            return Ok(result);
        }
    }
}
