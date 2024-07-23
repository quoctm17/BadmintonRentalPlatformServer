using BusinessObjects;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Request.User;
using DTOs.Response.Authentication;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.User;
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
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        Task<Result<List<UserDto>>> IUserService.GetList() => _repository.GetList();
        

        public Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request) => _repository.Login(request);
        public Task<Result<RegisterResponse>> Register(RegisterRequest request) => _repository.Register(request);

        public Task<Result<UserDto>> GetById(int id) => _repository.GetById(id);

        public Task<Result<UserDto>> Update(UpdateUserRequest request) => _repository.Update(request);

        public Task<Result<UserDto>> Delete(int id) => _repository.Delete(id);
        public string GenerateToken(string email)
        {
            return _repository.GenerateJwtToken(email);
        }

        public Task<Result<UserDto>> Create(CreateUserRequest request) => _repository.Create(request);
    }
}
