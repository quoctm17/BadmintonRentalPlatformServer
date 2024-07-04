using System.Net;
using BusinessObjects;
using BusinessObjects.Constants;
using DTOs.Request.Authentication;
using DTOs.Response.Authentication;
using DTOs;
using Microsoft.EntityFrameworkCore;
using Repositories.Utils;
using Mapster;
using Azure.Core;
using BusinessObjects.Exceptions;
using BusinessObjects.Helpers;
using BusinessObjects.Enums;

namespace DataAccessObject;

public class UserDAO
{
    private readonly AppDbContext _context;
    private static UserDAO instance;
    
    public UserDAO()
    {
        _context = new AppDbContext();
    }

    public static UserDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }
            return instance;
        }
    }
    public async Task<(Tuple<string, Guid>, Result<LoginResponse>, UserEntity user)> Login(LoginRequest request)
    {
        var user = await _context.Users.
            Include(user => user.Role)
            .SingleOrDefaultAsync(user => user.Email.Equals(request.Email) &&
                                          user.Password.Equals(request.Password));

        if (user == null) return (null, new Result<LoginResponse>
        {
            StatusCode = HttpStatusCode.BadRequest,
            Message = MessageConstant.Vi.User.Fail.NotFoundUser
        }, null)!;

        Tuple<string, Guid> guidClaim = null!;
        LoginResponse loginResponse = null!;

        loginResponse = new LoginResponse(user.Id, user.FullName, user.Email, user.Gender, user.DateOfBirth, user.Address, user.ProfileImage, user.PhoneNumber, EnumHelper.ParseEnum<RoleEnum>(user.Role.RoleName));

        var token = JwtUtil.GenerateJwtToken(user, guidClaim);
        loginResponse.AccessToken = token;

        return (guidClaim, new Result<LoginResponse> { Data = loginResponse, StatusCode = HttpStatusCode.OK }, user);
    }

    public async Task<(Tuple<string, Guid>, Result<RegisterResponse>, UserEntity user)> Register(RegisterRequest request)
    {
        var listUser = await _context.Users
            .Where(user => user.Email.Equals(request.Email))
            .ToListAsync();

        if (listUser.Any())
        {
            throw new BadRequestException(MessageConstant.Vi.User.Fail.EmailExisted);
        }

        UserEntity newUser = request.Adapt<UserEntity>();

        newUser.PasswordEncrypt = "PasswordEncrypt";

        try
        {
            await _context.Users.AddAsync(newUser);
            bool isSuccessful = await _context.SaveChangesAsync() > 0;
            if (!isSuccessful)
            {
                throw new Exception(MessageConstant.Vi.User.Fail.CreateUser);
            }

            newUser = await _context.Users.Include(x => x.Role)
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate: x => x.Id.Equals(newUser.Id));

            Tuple<string, Guid> guidClaim = null!;
            RegisterResponse registerResponse = null!;

            registerResponse = new RegisterResponse(newUser.Id, newUser.FullName, newUser.Email, newUser.Gender, newUser.DateOfBirth, newUser.Address, newUser.ProfileImage, newUser.PhoneNumber, EnumHelper.ParseEnum<RoleEnum>(newUser.Role.RoleName));

            var token = JwtUtil.GenerateJwtToken(newUser, guidClaim);
            registerResponse!.AccessToken = token;

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