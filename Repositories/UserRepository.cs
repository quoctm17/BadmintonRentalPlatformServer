using BusinessObjects;
using DataAccessObject;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Request.User;
using DTOs.Response.Authentication;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.User;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using Repositories.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        Task<Result<List<UserDto>>> IUserRepository.GetList() => UserDAO.Instance.GetList();

        public Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request) => UserDAO.Instance.Login(request);
        public Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> Register(RegisterRequest request) => UserDAO.Instance.Register(request);

        public Task<Result<UserDto>> GetById(int id) => UserDAO.Instance.GetById(id);

        public Task<Result<UserDto>> Update(UpdateUserRequest request) => UserDAO.Instance.Update(request);

        public Task<Result<UserDto>> Delete(int id) =>UserDAO.Instance.Delete(id);
        public string GenerateJwtToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.Day.ToString()),
                new Claim("UserName", email),
                new Claim("Role", "Admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:ValidIssuer"],
                _configuration["Jwt:ValidAudience"],
                claims,
                expires: DateTime.UtcNow.AddYears(4),
                signingCredentials: signIn
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<Result<UserDto>> Create(CreateUserRequest request) => UserDAO.Instance.Create(request);
    }
}
