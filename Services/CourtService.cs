using DataAccessObject;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interface;
using BusinessObjects;

namespace Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository _repository;
        public CourtService(ICourtRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<CourtDto>> Create(CourtRequest request) => _repository.Create(request);

        public Task<Result<CourtDto>> GetById(int id) => _repository.GetById(id);
        public Task<Result<List<CourtDetailDto>>> GetCourtsByBadmintonCourtId(int badmintonCourtId) => _repository.GetCourtsByBadmintonCourtId(badmintonCourtId);
    }
}
