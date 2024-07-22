using BusinessObjects.Constants;
using BusinessObjects.Exceptions;
using BusinessObjects;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DTOs.Request.CourtSlot;
using Mapster;
using DTOs.Response.CourtSlot;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public class CourtSlotDAO
    {
        private readonly AppDbContext _context;
        private static CourtSlotDAO instance;

        public CourtSlotDAO()
        {
            _context = new AppDbContext();
        }

        public static CourtSlotDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourtSlotDAO();
                }
                return instance;
            }
        }

        public async Task AddNew(CourtSlotEntity courtSlotEntity)
        {
            await _context.CourtSlots.AddAsync(courtSlotEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<Result<CourtSlotDto>> Create(CourtSlotRequest request)
        {
            try
            {
                CourtEntity? court = _context.Courts.SingleOrDefault(x => x.Id.Equals(request.CourtNumberId));
                if (court == null) throw new BadRequestException(MessageConstant.Vi.Court.Fail.NotFoundCourt);

                CourtSlotEntity courtSlot = request.Adapt<CourtSlotEntity>();

                await _context.CourtSlots.AddAsync(courtSlot);
                bool isSuccessful = await _context.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.CourtSlot.Fail.CreateCourtSlot);
                }         

                return new Result<CourtSlotDto>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = courtSlot.Adapt<CourtSlotDto>(),
                };

            }
            catch (Exception ex)
            {
                return new Result<CourtSlotDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                };
            }
        }

        public async Task<List<CourtSlotEntity>> GetAllCourtSlots()
        {
            return await _context.CourtSlots
                .ToListAsync();
        }
    }
}
