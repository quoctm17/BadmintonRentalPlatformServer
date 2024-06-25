using AutoMapper;
using BusinessObjects;
using BusinessObjects.Constants;
using DataAccessObject;
using DTOs;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using Repositories.Interface;
using System.Net;

namespace Repositories
{
    public class BadmintonCourtRepository : IBadmintonCourtRepository
    {
        private readonly AppDbContext? _dbContext = null;
        private readonly IMapper _mapper = null;

        public BadmintonCourtRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request)
        {
            try
            {
                var newBadmintonCourt = _mapper.Map<BadmintonCourtEntity>(request);

                await _dbContext.BadmintonCourts.AddAsync(newBadmintonCourt);
                bool isSuccessful = await _dbContext.SaveChangesAsync() > 0;

                if (!isSuccessful)
                {
                    throw new Exception(MessageConstant.Vi.BadmintonCourt.Fail.CreateBadmintonCourt);
                }

                return new Result<BadmintonCourtDto> {
                    StatusCode = HttpStatusCode.OK,
                    Data = _mapper.Map<BadmintonCourtDto>(newBadmintonCourt),
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
}
