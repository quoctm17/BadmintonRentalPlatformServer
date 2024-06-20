using BadmintonRentalPlatformAPI.Utils;
using BusinessObjects.Constants;
using BusinessObjects;
using DTOs.Request.Authentication;
using DTOs.Response.Authentication;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;
using DTOs.Response.AuthenPlayer;
using DTOs.Request.AuthenPlayer;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class PlayerAuthController : BaseController<PlayerAuthController>
    {
        private readonly IUserService _userService;

        public PlayerAuthController(ILogger<PlayerAuthController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpPut(ApiEndPointConstant.PlayerAuth.LoginEndPoint)]
        [ProducesResponseType(typeof(Result<PlayerLoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> PlayerLogin([FromBody] PlayerLoginRequest request)
        {
            (Tuple<string, Guid>, Result<PlayerLoginResponse>, UserEntity) result = await _userService.PlayerLogin(request);
            return StatusCode((int)result.Item2.StatusCode, result.Item2);
        }

        [HttpPut(ApiEndPointConstant.PlayerAuth.RegisterEndPoint)]
        [ProducesResponseType(typeof(Result<PlayerRegisterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PlayerRegister([FromBody] PlayerRegisterRequest request)
        {
            (Tuple<string, Guid>, Result<PlayerRegisterResponse>, UserEntity) result = await _userService.PlayerRegister(request);
            return StatusCode((int)result.Item2.StatusCode, result.Item2);
        }
    }
}
