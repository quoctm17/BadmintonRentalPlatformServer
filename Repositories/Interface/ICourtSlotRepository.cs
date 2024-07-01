using DTOs.Request.CourtSlot;
using DTOs.Response.CourtSlot;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICourtSlotRepository
    {
        Task<Result<CourtSlotDto>> Create(CourtSlotRequest request);
    }
}
