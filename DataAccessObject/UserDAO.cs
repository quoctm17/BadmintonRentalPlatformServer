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
using DTOs.Response.BadmintonCourt;
using DTOs.Response.User;
using DTOs.Request.BadmintonCourt;
using DTOs.Request.User;

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

    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
        var listUser = await _context.Users
            .Where(user => user.Email.Equals(request.Email))
            .ToListAsync();

        if (listUser.Any())
        {
            throw new BadRequestException(MessageConstant.Vi.User.Fail.EmailExisted);
        }

        UserEntity newUser = request.Adapt<UserEntity>();
        newUser.Address = "";
        newUser.ProfileImage = "default";
        newUser.RoleId = 1;

        newUser.PasswordEncrypt = "PasswordEncrypt";
        await _context.Users.AddAsync(newUser);
        bool isSuccessful = await _context.SaveChangesAsync() > 0;
        if (!isSuccessful)
        {
            throw new Exception(MessageConstant.Vi.User.Fail.CreateUser);
        }

        newUser = await _context.Users
            .Include(x => x.Role)
            .AsNoTracking()
            .SingleOrDefaultAsync(predicate: x => x.Id.Equals(newUser.Id));

        Tuple<string, Guid> guidClaim = null!;
        RegisterResponse registerResponse = null!;

        registerResponse = new RegisterResponse(newUser.Id, newUser.FullName, newUser.Email, newUser.Gender, newUser.DateOfBirth, newUser.Address, newUser.ProfileImage, newUser.PhoneNumber, EnumHelper.ParseEnum<RoleEnum>(newUser.Role.RoleName));

        var token = JwtUtil.GenerateJwtToken(newUser, guidClaim);
        registerResponse!.AccessToken = token;

        return registerResponse;
    
    }

    public async Task<Result<List<UserDto>>> GetList()
    {
        try
        {
                List<UserEntity> user = await _context.Users
                                               .Include(user => user.Role)
                .AsNoTracking()
                .ToListAsync()
                ?? throw new Exception(MessageConstant.Vi.User.Fail.NotFoundUser);
            var users = user.Adapt<List<UserDto>>();
            for (int i = 0; i < user.Count; i++)
            {
                users[i].RoleName = user[i].Role.RoleName;
            }
            return new Result<List<UserDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = users
            };

        }
        catch (Exception ex)
        {
            return new Result<List<UserDto>>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = ex.Message,

            };
        }
    }

    public async Task<Result<UserDto>> GetById(int id)
    {
        try
        {
            UserEntity user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception(MessageConstant.Vi.User.Fail.NotFoundUser);
            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = user.Adapt<UserDto>()
            };

        }
        catch (Exception ex)
        {
            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = ex.Message,

            };
        }
    }

    public async Task<Result<UserDto>> Update(UpdateUserRequest request)
    {
        try
        {
            UserEntity? user = await _context.Users.SingleOrDefaultAsync(c => c.Id == request.Id);
            if (user == null)
            {
                throw new BadRequestException(MessageConstant.Vi.User.Fail.NotFoundUser);
            }


            request.Adapt(user);

            _context.Users.Update(user);
            bool isSuccessful = await _context.SaveChangesAsync() > 0;

            if (!isSuccessful)
            {
                throw new Exception(MessageConstant.Vi.User.Fail.UpdateUser);
            }

            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = user.Adapt<UserDto>(),
            };
        }
        catch (Exception ex)
        {
            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
            };
        }
    }

    public async Task<Result<UserDto>> Create(CreateUserRequest request)
    {
        try
        {
            UserEntity newUser = request.Adapt<UserEntity>();

            await _context.Users.AddAsync(newUser);
            bool isSuccessful = await _context.SaveChangesAsync() > 0;

            if (!isSuccessful)
            {
                throw new Exception(MessageConstant.Vi.User.Fail.CreateUser);
            }

            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = newUser.Adapt<UserDto>(),
            };
        }
        catch (Exception ex)
        {
            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
            };
        }
    }

    public async Task<Result<UserDto>> Delete(int id)
    {
        try
        {
            UserEntity user = await _context.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                 ?? throw new Exception(MessageConstant.Vi.User.Fail.NotFoundUser);

            _context.Users.Remove(user);
            bool isSuccessful = await _context.SaveChangesAsync() > 0;

            if (!isSuccessful)
            {
                throw new Exception(MessageConstant.Vi.User.Fail.DeleteUser);
            }

            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = user.Adapt<UserDto>(),
            };

        }
        catch (Exception ex)
        {
            return new Result<UserDto>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
            };
        }
    }
}