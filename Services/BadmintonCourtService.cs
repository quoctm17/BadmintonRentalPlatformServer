using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using DTOs;
using Microsoft.Extensions.Logging;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BadmintonCourtService : IBadmintonCourtService
    {
        private readonly IBadmintonCourtRepository _repository;
        public BadmintonCourtService(IBadmintonCourtRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request) => _repository.Create(request);

        public Task<Result<BadmintonCourtDto>> Delete(int id) => _repository.Delete(id);

        public Task<Result<BadmintonCourtDto>> GetById(int id) => _repository.GetById(id);

        public Task<Result<BadmintonCourtDto>> Update(UpdateBadmintonCourtRequest request) => _repository.Update(request);

        Task<Result<List<BadmintonCourtDto>>> IBadmintonCourtService.GetList() => _repository.GetList();
    }
}
