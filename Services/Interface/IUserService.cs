using DTOs.Request.Authentication;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Response.Authentication;
using DTOs;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.User;
using DTOs.Request.User;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request);
        Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> Register(RegisterRequest request);
        Task<Result<List<UserDto>>> GetList();
        Task<Result<UserDto>> GetById(int id);
        Task<Result<UserDto>> Update(UpdateUserRequest request);
        Task<Result<UserDto>> Create(CreateUserRequest request);
        Task<Result<UserDto>> Delete(int id);
        public string GenerateToken(string email);
    }
}
