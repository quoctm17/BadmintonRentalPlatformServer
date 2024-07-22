using DTOs.Request.CourtSlot;
using DTOs.Response.CourtSlot;
using DTOs;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessObject;

namespace Repositories
{
    public class CourtSlotRepository : ICourtSlotRepository
    {
        public CourtSlotRepository() { }

        public Task<Result<CourtSlotDto>> Create(CourtSlotRequest request) => CourtSlotDAO.Instance.Create(request);
        public async Task<Result<List<CourtSlotEntity>>> GetAllCourtSlots()
        {
            return new Result<List<CourtSlotEntity>>()
            {
                StatusCode = HttpStatusCode.OK,
                Data = await CourtSlotDAO.Instance.GetAllCourtSlots()
            };
        }
    }
}
