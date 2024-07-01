using BusinessObjects.Constants;
using DTOs.Request.TypeOfCourt;
using DTOs.Response.TypeOfCourt;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTOs.Response.Court;
using DTOs.Request.Court;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class CourtController : BaseController<CourtController>
    {
        private readonly ICourtService _service;

        public CourtController(ILogger<CourtController> logger, ICourtService service) : base(logger)
        {
            _service = service;
        }

        [HttpPost(ApiEndPointConstant.Court.CourtsEndpoint)]
        [ProducesResponseType(typeof(Result<CourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CourtRequest request)
        {
            Result<CourtDto> result = await _service.Create(request);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
