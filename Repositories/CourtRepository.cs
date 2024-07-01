using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject;

namespace Repositories
{
    public class CourtRepository : ICourtRepository
    {
        public CourtRepository() { }

        public Task<Result<CourtDto>> Create(CourtRequest request) => CourtDAO.Instance.Create(request);
    }
}
