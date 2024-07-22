using System.Net;
using BusinessObjects;
using BusinessObjects.Constants;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Response.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace BadmintonRentalPlatformAPI.Controllers
{
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger, 
            IUserService userService,
            IConfiguration configuration) : base(logger)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost(ApiEndPointConstant.Authentication.LoginEndPoint)]
        [ProducesResponseType(typeof(Result<LoginResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            (Tuple<string, Guid>, Result<LoginResponse>, UserEntity) result = await _userService.Login(request);

            return StatusCode((int)result.Item2.StatusCode, result.Item2);
        }

        [HttpPost(ApiEndPointConstant.Authentication.RegisterEndPoint)]
        [ProducesResponseType(typeof(Result<RegisterResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> OwnerRegister([FromBody] RegisterRequest request)
        {
            (Tuple<string, Guid>, Result<RegisterResponse>, UserEntity) result = await _userService.Register(request);

            return StatusCode((int)result.Item2.StatusCode, result.Item2);
        }

        [HttpPost("login-admin")]
        public async Task<IActionResult> LoginAdmin(string email, string password)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var emailAdmin = _configuration.GetSection("AdminAccount:Email").Value ?? string.Empty;
            var passwordAdmin = _configuration.GetSection("AdminAccount:Password").Value ?? string.Empty;
            if (email.Equals(emailAdmin) && password.Equals(passwordAdmin))
            {
                var token = _userService.GenerateToken(email);
                return Ok(new Result<string>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = token
                });
            }
            return Ok(new Result<string>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Data = "Wrong username or password"
            });
        }
    }
}
