using BusinessObjects;
using BusinessObjects.Constants;
using BusinessObjects.Enums;
using DataAccessObject;
using DTOs;
using DTOs.Request.Authentication;
using DTOs.Response.Authentication;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
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
        private readonly AppDbContext? _dbContext = null;
        private static UserRepository? _instance = null;

        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserRepository();
                }

                return _instance;
            }
        }

        public UserRepository()
        {
            _dbContext = new AppDbContext();
        }

        public async Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request)
        {
            UserEntity? user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email.Equals(request.Email) && x.Password.Equals(request.Password));

            if (user == null) return (null, new Result<LoginResponse>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = MessageConstant.Vi.User.Fail.NotFoundUser
            }, null)!;

            Tuple<string, Guid> guidClaim = null!;
            LoginResponse loginResponse = null!;

            loginResponse = new LoginResponse(user.Id, user.FullName, user.Email);

            return (guidClaim, new Result<LoginResponse> { Data = loginResponse, StatusCode = HttpStatusCode.OK }, user);
        }

        public async Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> OwnerRegister(RegisterRequest request)
        {
            var listUser = _dbContext.Users.Where(predicate: x => x.Email == request.Email);

            if (listUser.Any())
            {
                throw new Exception(MessageConstant.Vi.User.Fail.EmailExisted);
            }

            UserEntity newUser = new UserEntity()
            {
                FullName = request.FullName,
                Email = request.Email,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Password = request.Password,
                PasswordEncrypt = "123",
                ProfileImage = request.ProfileImage,
                PhoneNumber = request.PhoneNumber
            };

            try
            {
                await _dbContext.Users.AddAsync(newUser);

                UserRoleEntity newRole = new UserRoleEntity()
                {
                    User = newUser,
                    RoleId = _dbContext.Roles.SingleOrDefault(x => x.RoleName.Equals("Owner"))!.Id,
                };

                await _dbContext.UserRoles.AddAsync(newRole);

                bool isSuccessful = await _dbContext.SaveChangesAsync() > 0;
                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.User.Fail.CreateUser);
                }

                Tuple<string, Guid> guidClaim = null!;
                RegisterResponse registerResponse = null!;

                registerResponse = new RegisterResponse(newUser.Id, newUser.FullName, newUser.Email);

                return (guidClaim, new Result<RegisterResponse> { Data = registerResponse, StatusCode = HttpStatusCode.OK }, newUser);
            }
            catch (Exception ex)
            {
                return (null, new Result<RegisterResponse>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                }, null)!;
            }
        }
    }
}
