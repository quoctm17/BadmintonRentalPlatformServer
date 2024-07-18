using BusinessObjects.Constants;
using DTOs.Response.BadmintonCourt;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interface;
using DTOs.Response.User;
using DTOs.Request.BadmintonCourt;
using DTOs.Request.User;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpGet(ApiEndPointConstant.User.UsersEndpoint)]
        [ProducesResponseType(typeof(Result<List<UserDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Users()
        {
            var result = await _userService.GetList();
            return StatusCode((int)result.StatusCode, result);
        }


        [HttpGet(ApiEndPointConstant.User.UserEndpoint)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Users([FromRoute] int id)
        {
            var result = await _userService.GetById(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost(ApiEndPointConstant.User.UsersEndpoint)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            Result<UserDto> result = await _userService.Create(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPut(ApiEndPointConstant.User.UsersEndpoint)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            Result<UserDto> result = await _userService.Update(request);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete(ApiEndPointConstant.User.UserEndpoint)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Result<UserDto> result = await _userService.Delete(id);
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
