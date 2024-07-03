using BusinessObjects.Constants;
using BusinessObjects;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DTOs.Response.Court;
using DTOs.Request.Court;
using Mapster;
using BusinessObjects.Exceptions;
using DTOs.Response.BadmintonCourt;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public class CourtDAO
    {
        private readonly AppDbContext _context;
        private static CourtDAO instance;

        public CourtDAO()
        {
            _context = new AppDbContext();
        }

        public static CourtDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourtDAO();
                }
                return instance;
            }
        }

        public async Task<Result<CourtDto>> Create(CourtRequest request)
        {
            try
            {
                TypeOfCourtEntity? typeOfCourt = _context.TypeOfCourts.SingleOrDefault(x => x.Id.Equals(request.TypeOfCourtId));
                if (typeOfCourt == null) throw new BadRequestException(MessageConstant.Vi.TypeOfCourt.Fail.NotFoundTypeOfCourt);

                BadmintonCourtEntity? badmintonCourt = _context.BadmintonCourts.SingleOrDefault(x => x.Id.Equals(request.BadmintonCourtId));
                if (badmintonCourt == null) throw new BadRequestException(MessageConstant.Vi.BadmintonCourt.Fail.NotFoundBadmintonCourt);

                CourtEntity court = request.Adapt<CourtEntity>();

                await _context.Courts.AddAsync(court);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.TypeOfCourt.Fail.CreateTypeOfCourt);
                }

                return new Result<CourtDto>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = court.Adapt<CourtDto>(),
                };

            }
            catch (Exception ex)
            {
                return new Result<CourtDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }
        public async Task<Result<CourtDto>> GetById(int id)
        {
            try
            {
                CourtEntity court = await _context.Courts
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id)
                    ?? throw new Exception(MessageConstant.Vi.Court.Fail.NotFoundCourt);
                return new Result<CourtDto>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = court.Adapt<CourtDto>()
                };

            }
            catch (Exception ex)
            {
                return new Result<CourtDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = ex.Message,

                };
            }
        }
    }
}
