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

namespace Services
{
    public class CourtService : ICourtService
    {
        public CourtService() { }

        public Task<Result<CourtDto>> Create(CourtRequest request) => CourtDAO.Instance.Create(request);

        public Task<Result<CourtDto>> GetById(int id) => CourtDAO.Instance.GetById(id);
    }
}
