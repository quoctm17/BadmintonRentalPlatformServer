using BusinessObjects.Constants;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;
using DTOs.Response.TypeOfCourt;
using DTOs.Request.TypeOfCourt;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class TypeOfCourtController : BaseController<TypeOfCourtController>
    {
        private readonly ITypeOfCourtService _service;

        public TypeOfCourtController(ILogger<TypeOfCourtController> logger, ITypeOfCourtService service) : base(logger)
        {
            _service = service;
        }

        [HttpPost(ApiEndPointConstant.TypeOfCourt.TypeOfCourtsEndpoint)]
        [ProducesResponseType(typeof(Result<TypeOfCourtDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TypeOfCourtRequest request)
        {
            Result<TypeOfCourtDto> result = await _service.Create(request);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
