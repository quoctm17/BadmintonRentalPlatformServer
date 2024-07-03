﻿using BusinessObjects;
using BusinessObjects.Constants;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using DTOs;
using System.Net;
using Mapster;
using BusinessObjects.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            UserEntity? user = _context.Users.SingleOrDefault(u => u.Id.Equals(request.CourtOwnerId));
            if (user == null) throw new BadRequestException(MessageConstant.Vi.User.Fail.NotFoundUser);
            
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
    public async Task<Result<BadmintonCourtDto>> GetById(int id)
    {
        try
        {
            BadmintonCourtEntity badmintonCourt = await _context.BadmintonCourts
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception(MessageConstant.Vi.BadmintonCourt.Fail.NotFoundBadmintonCourt);
            return new Result<BadmintonCourtDto>
            {
                StatusCode = HttpStatusCode.OK,
                Data = badmintonCourt.Adapt<BadmintonCourtDto>()
            };
           
        }catch (Exception ex)
        {
            return new Result<BadmintonCourtDto>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = ex.Message,

            };
        }
    }
    public async Task<Result<List<BadmintonCourtDto>>> GetList()
    {
        try
        {
            ICollection<BadmintonCourtEntity> badmintonCourt = await _context.BadmintonCourts
                .AsNoTracking()
                .ToListAsync()
                ?? throw new Exception(MessageConstant.Vi.BadmintonCourt.Fail.NotFoundBadmintonCourt);
            return new Result<List<BadmintonCourtDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = badmintonCourt.Adapt<List<BadmintonCourtDto>>()
            };

        }
        catch (Exception ex)
        {
            return new Result<List<BadmintonCourtDto>>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = ex.Message,

            };
        }
    }
    public async Task<Result<List<BadmintonCourtDto>>> GetPaging(int page, int size)
    {
        try
        {
            ICollection<BadmintonCourtEntity> badmintonCourt = await _context.BadmintonCourts
                .AsNoTracking()
                .Skip((page - 1) * size).Take(size)
                .ToListAsync()
                ?? throw new Exception(MessageConstant.Vi.BadmintonCourt.Fail.NotFoundBadmintonCourt);
            return new Result<List<BadmintonCourtDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Data = badmintonCourt.Adapt<List<BadmintonCourtDto>>()
            };

        }
        catch (Exception ex)
        {
            return new Result<List<BadmintonCourtDto>>
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = ex.Message,

            };
        }
    }
}