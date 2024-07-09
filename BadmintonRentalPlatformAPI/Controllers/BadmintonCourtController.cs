using BusinessObjects.Constants;
using DTOs;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class BadmintonCourtController : BaseController<BadmintonCourtController>
    {
        private readonly IBadmintonCourtService _badmintonCourtService;

        public BadmintonCourtController(ILogger<BadmintonCourtController> logger, IBadmintonCourtService badmintonCourtService) : base(logger)
        {
            _badmintonCourtService = badmintonCourtService;
        }

        [HttpPost(ApiEndPointConstant.BadmintonCourt.BadmintonCourtsEndpoint)]
        [ProducesResponseType(typeof(Result<BadmintonCourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        
        public async Task<IActionResult> Create([FromBody] CreateBadmintonCourtRequest request)
        {
            Result<BadmintonCourtDto> result = await _badmintonCourtService.Create(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet(ApiEndPointConstant.BadmintonCourt.BadmintonCourtEndpoint)]
        [ProducesResponseType(typeof(Result<BadmintonCourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BadmintonCourts([FromRoute] int id)
        {
            var result = await _badmintonCourtService.GetById(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpGet(ApiEndPointConstant.BadmintonCourt.BadmintonCourtsEndpoint)]
        [ProducesResponseType(typeof(Result<List<BadmintonCourtDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BadmintonCourts()
        {
            var result = await _badmintonCourtService.GetList();
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPut(ApiEndPointConstant.BadmintonCourt.BadmintonCourtsEndpoint)]
        [ProducesResponseType(typeof(Result<BadmintonCourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateBadmintonCourtRequest request)
        {
            Result<BadmintonCourtDto> result = await _badmintonCourtService.Update(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete(ApiEndPointConstant.BadmintonCourt.BadmintonCourtEndpoint)]
        [ProducesResponseType(typeof(Result<BadmintonCourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Result<BadmintonCourtDto> result = await _badmintonCourtService.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
