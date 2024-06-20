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
        Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> OwnerRegister(RegisterRequest request);

        Task<(Tuple<string, Guid>, Result<PlayerLoginResponse>, UserEntity user)> PlayerLogin(PlayerLoginRequest request);
        Task<(Tuple<string, Guid>, Result<PlayerRegisterResponse>, UserEntity user)> PlayerRegister(PlayerRegisterRequest request);
    }
}
