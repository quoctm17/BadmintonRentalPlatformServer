using BusinessObjects;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Request.User;
using DTOs.Response.Authentication;
using DTOs.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IUserRepository
    {
        Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request);
        Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> Register(RegisterRequest request);
        Task<Result<List<UserDto>>> GetList();
        Task<Result<UserDto>> GetById(int id);
        Task<Result<UserDto>> Update(UpdateUserRequest request);
        Task<Result<UserDto>> Create(CreateUserRequest request);
        Task<Result<UserDto>> Delete(int id);

        public string GenerateJwtToken(string email);
    }
}
