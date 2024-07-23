using DTOs.Request.CourtSlot;
using DTOs.Response.CourtSlot;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface ICourtSlotRepository
    {
        Task<Result<CourtSlotDto>> Create(CourtSlotRequest request);
        public Task<Result<List<CourtSlotEntity>>> GetAllCourtSlots();

        public Task<Result<List<CourtSlotTimeDto>>> GetAllSlotByDateAndBadmintonCourt(int badmintonCourtId, DateTime date);
    }
}
