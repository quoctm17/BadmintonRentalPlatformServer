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
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {
        }

        Task<Result<List<UserDto>>> IUserRepository.GetList() => UserDAO.Instance.GetList();

        public Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request) => UserDAO.Instance.Login(request);
        public Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> Register(RegisterRequest request) => UserDAO.Instance.Register(request);

        public Task<Result<UserDto>> GetById(int id) => UserDAO.Instance.GetById(id);

        public Task<Result<UserDto>> Update(UpdateUserRequest request) => UserDAO.Instance.Update(request);

        public Task<Result<UserDto>> Delete(int id) =>UserDAO.Instance.Delete(id);

        public Task<Result<UserDto>> Create(CreateUserRequest request) => UserDAO.Instance.Create(request);
    }
}
