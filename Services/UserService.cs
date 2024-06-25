using BusinessObjects;
using DTOs;
using DTOs.Request.AuthenPlayer;
using DTOs.Request.Authentication;
using DTOs.Response.AuthenPlayer;
using DTOs.Response.Authentication;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ILogger _logger;
        public UserService(IUserRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request) => _repository.Login(request);

        public Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> OwnerRegister(RegisterRequest request) => _repository.OwnerRegister(request);

        public Task<(Tuple<string, Guid>, Result<PlayerLoginResponse>, UserEntity user)> PlayerLogin(PlayerLoginRequest request) => _repository.PlayerLogin(request);

        public Task<(Tuple<string, Guid>, Result<PlayerRegisterResponse>, UserEntity user)> PlayerRegister(PlayerRegisterRequest request) => _repository.PlayerRegister(request);
    }
}
