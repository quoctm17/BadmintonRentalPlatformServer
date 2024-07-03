using BusinessObjects;
using DataAccessObject;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Response.Authentication;
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

        public Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request) => UserDAO.Instance.Login(request);
        public Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> Register(RegisterRequest request) => UserDAO.Instance.Register(request);
    }
}
