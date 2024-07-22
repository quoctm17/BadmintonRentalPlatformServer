using BusinessObjects.Constants;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTOs.Response.CourtSlot;
using DTOs.Request.CourtSlot;

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
    }
}
