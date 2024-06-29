using BusinessObjects;
using DTOs;
using DTOs.Request.AuthenPlayer;
using DTOs.Request.Authentication;
using DTOs.Response.AuthenPlayer;
using DTOs.Response.Authentication;
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
    }
}
