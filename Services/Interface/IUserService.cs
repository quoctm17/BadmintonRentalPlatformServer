using DTOs.Request.Authentication;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Response.Authentication;
using DTOs;
using DTOs.Response.AuthenPlayer;
using DTOs.Request.AuthenPlayer;

namespace Services.Interface
{
    public interface IUserService
    {
        Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request);
        Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> OwnerRegister(RegisterRequest request);

        Task<(Tuple<string, Guid>, Result<PlayerLoginResponse>, UserEntity user)> PlayerLogin(PlayerLoginRequest request);
        Task<(Tuple<string, Guid>, Result<PlayerRegisterResponse>, UserEntity user)> PlayerRegister(PlayerRegisterRequest request);
    }
}
