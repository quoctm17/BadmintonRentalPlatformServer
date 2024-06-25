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
        private readonly ILogger _logger;
        public BadmintonCourtService(IBadmintonCourtRepository repository, ILogger<UserService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request) => _repository.Create(request);
    }
}
