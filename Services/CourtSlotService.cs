using DataAccessObject;
using DTOs.Request.CourtSlot;
using DTOs.Response.CourtSlot;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CourtSlotService : ICourtSlotService
    {
        public CourtSlotService() { }

        public Task<Result<CourtSlotDto>> Create(CourtSlotRequest request) => CourtSlotDAO.Instance.Create(request);
    }
}
