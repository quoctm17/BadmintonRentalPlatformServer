using AutoMapper;
using BusinessObjects;
using BusinessObjects.Constants;
using BusinessObjects.Enums;
using BusinessObjects.Helpers;
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
        private readonly IMapper _mapper = null;

        public UserRepository(IMapper mapper)
        {
            _dbContext = new AppDbContext();
            _mapper = mapper;
        }

        public async Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request)
        {
            UserEntity? user = await _dbContext.Users.
                Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .SingleOrDefaultAsync(x => x.Email.Equals(request.Email) && x.Password.Equals(request.Password) && x.UserRoles.Any(x => x.Role.RoleName.Equals("Owner")));

            if (user == null) return (null, new Result<LoginResponse>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = MessageConstant.Vi.User.Fail.NotFoundUser
            }, null)!;

            var ownerRole = _dbContext.Roles.SingleOrDefault(x => x.RoleName.Equals("Owner"))!.RoleName;

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

            UserEntity newUser = _mapper.Map<UserEntity>(request);
            // Cant null so just hard code.
            newUser.PasswordEncrypt = "123";

            newUser.UserRoles = new List<UserRoleEntity>();

            try
            {
                newUser.UserRoles.Add(new UserRoleEntity()
                {
                    User = newUser,
                    RoleId = _dbContext.Roles.SingleOrDefault(x => x.RoleName.Equals("Owner"))!.Id,
                });

                await _dbContext.Users.AddAsync(newUser);
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
