using BadmintonRentalPlatformAPI.Utils;
using BusinessObjects;
using BusinessObjects.Constants;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Response.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly IUserService _userService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpPut(ApiEndPointConstant.Authentication.LoginEndPoint)]
        [ProducesResponseType(typeof(Result<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            (Tuple<string, Guid>, Result<LoginResponse>, UserEntity) result = await _userService.Login(request);
            if (result.Item2.Data != null)
            {
                var token = JwtUtil.GenerateJwtToken(result.Item3, result.Item1);
                result.Item2.Data!.AccessToken = token;
            }
            return StatusCode((int)result.Item2.StatusCode, result.Item2);
        }

        [HttpPut(ApiEndPointConstant.Authentication.RegisterEndPoint)]
        [ProducesResponseType(typeof(Result<RegisterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> OwnerRegister([FromBody] RegisterRequest request)
        {
            (Tuple<string, Guid>, Result<RegisterResponse>, UserEntity) result = await _userService.OwnerRegister(request);
            if (result.Item2.Data != null)
            {
                var token = JwtUtil.GenerateJwtToken(result.Item3, result.Item1);
                result.Item2.Data!.AccessToken = token;
            }
            return StatusCode((int)result.Item2.StatusCode, result.Item2);
        }
    }
}
