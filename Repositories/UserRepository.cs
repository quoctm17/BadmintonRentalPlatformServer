using AutoMapper;
using BusinessObjects;
using BusinessObjects.Constants;
using BusinessObjects.Enums;
using BusinessObjects.Helpers;
using DataAccessObject;
using DTOs;
using DTOs.Request.AuthenPlayer;
using DTOs.Request.Authentication;
using DTOs.Response.AuthenPlayer;
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
        private readonly IMapper _mapper = null;

        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request)
        {
            var user = await UserDAO.Instance.LoginOwner(request.Email, request.Password);
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
            var listUser = await UserDAO.Instance.GetUserByEmail(request.Email);

            if (listUser.Any())
            {
                throw new Exception(MessageConstant.Vi.User.Fail.EmailExisted);
            }

            UserEntity newUser = _mapper.Map<UserEntity>(request);

            newUser.PasswordEncrypt = "123";

            newUser.UserRoles = new List<UserRoleEntity>();

            try
            {
                var role = await RoleDAO.Instance.GetRoleName("Owner");
                newUser.UserRoles.Add(new UserRoleEntity()
                {
                    User = newUser,
                    RoleId = role!.Id,
                });

                bool isSuccessful = await UserDAO.Instance.AddNewUser(newUser) > 0;
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
        public async Task<(Tuple<string, Guid>, Result<PlayerLoginResponse>, UserEntity user)> PlayerLogin(PlayerLoginRequest request)
        {
            var user = await UserDAO.Instance.LoginPlayer(request.Email, request.Password);
            if (user == null) return (null, new Result<PlayerLoginResponse>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = MessageConstant.Vi.User.Fail.NotFoundUser
            }, null)!;

            Tuple<string, Guid> guidClaim = null!;
            PlayerLoginResponse playerLoginResponse = null!;

            playerLoginResponse = new PlayerLoginResponse(user.Id, user.FullName, user.Email);

            return (guidClaim, new Result<PlayerLoginResponse> { Data = playerLoginResponse, StatusCode = HttpStatusCode.OK }, user);
        }
        public async Task<(Tuple<string, Guid>, Result<PlayerRegisterResponse>, UserEntity user)> PlayerRegister(PlayerRegisterRequest request)
        {
            var listUser = await UserDAO.Instance.GetUserByEmail(request.Email);

            if (listUser.Any())
            {
                throw new Exception(MessageConstant.Vi.User.Fail.EmailExisted);
            }

            UserEntity newUser = _mapper.Map<UserEntity>(request);

            newUser.PasswordEncrypt = "";
            newUser.Gender = "";
            newUser.PhoneNumber = "";
            newUser.DateOfBirth = DateTime.Now;
            newUser.ProfileImage = "";

            newUser.UserRoles = new List<UserRoleEntity>();

            try
            {
                var role = await RoleDAO.Instance.GetRoleName("Player");
                newUser.UserRoles.Add(new UserRoleEntity()
                {
                    User = newUser,
                    RoleId = role!.Id,
                });

                bool isSuccessful = await UserDAO.Instance.AddNewUser(newUser) > 0;
                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.User.Fail.CreateUser);
                }

                Tuple<string, Guid> guidClaim = null!;
                PlayerRegisterResponse playerRegisterResponse = null!;

                playerRegisterResponse = new PlayerRegisterResponse(newUser.Id, newUser.FullName, newUser.Email);

                return (guidClaim, new Result<PlayerRegisterResponse> { Data = playerRegisterResponse, StatusCode = HttpStatusCode.OK }, newUser);
            }
            catch (Exception ex)
            {
                return (null, new Result<PlayerRegisterResponse>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                }, null)!;
            }
        }
    }
}
