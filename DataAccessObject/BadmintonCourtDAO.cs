using BusinessObjects;
using BusinessObjects.Constants;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using DTOs;
using System.Net;
using Mapster;
using BusinessObjects.Exceptions;

namespace DataAccessObject;

public class BadmintonCourtDAO
{
    private readonly AppDbContext _context;
    private static BadmintonCourtDAO instance;
    
    public BadmintonCourtDAO()
    {
        _context = new AppDbContext();
    }

    public static BadmintonCourtDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BadmintonCourtDAO();
            }
            return instance;
        }
    }

    public async Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request)
    {
        try
        {
            UserEntity user = _context.Users.SingleOrDefault(u => u.Id.Equals(request.CourtOwnerId));

            if (user == null)
            {
                throw new BadRequestException(MessageConstant.Vi.User.Fail.NotFoundUser);
            }

            BadmintonCourtEntity newBadmintonCourt = request.Adapt<BadmintonCourtEntity>();

            await _context.BadmintonCourts.AddAsync(newBadmintonCourt);
            bool isSuccessful = await _context.SaveChangesAsync() > 0;

            if (!isSuccessful)
            {
                throw new Exception(MessageConstant.Vi.BadmintonCourt.Fail.CreateBadmintonCourt);
            }

            return new Result<BadmintonCourtDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = newBadmintonCourt.Adapt<BadmintonCourtDto>(),
            };
        }
        catch (Exception ex)
        {
            return new Result<BadmintonCourtDto>
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = ex.Message,
            };
        }
    }
}