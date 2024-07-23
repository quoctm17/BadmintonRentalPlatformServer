using DataAccessObject;
using DTOs.Request.CourtSlot;
using DTOs.Response.CourtSlot;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories.Interface;

namespace Services
{
    public class CourtSlotService : ICourtSlotService
    {
        private readonly ICourtSlotRepository _repository;
        public CourtSlotService(ICourtSlotRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<CourtSlotDto>> Create(CourtSlotRequest request) => CourtSlotDAO.Instance.Create(request);
        public async Task<Result<List<CourtSlotEntity>>> GetAllCourtSlots()
        {
            return await _repository.GetAllCourtSlots();
        }

        public async Task<Result<List<CourtSlotEntity>>> GetAllCourtSlotsByDateAndBadmintonCourt(int badmintonCourtId, DateTime date)
        {
            return await _repository.GetAllSlotByDateAndBadmintonCourt(badmintonCourtId, date);
        }
    }
}
