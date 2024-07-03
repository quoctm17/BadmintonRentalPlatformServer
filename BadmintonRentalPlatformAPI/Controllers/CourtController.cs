using BusinessObjects.Constants;
using DTOs.Request.TypeOfCourt;
using DTOs.Response.TypeOfCourt;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using DTOs.Response.Court;
using DTOs.Request.Court;
using DTOs.Response.BadmintonCourt;
using Services;

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

        [HttpGet(ApiEndPointConstant.Court.CourtEndpoint)]
        [ProducesResponseType(typeof(Result<CourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Courts([FromRoute] int id)
        {
            var result = await _service.GetById(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
