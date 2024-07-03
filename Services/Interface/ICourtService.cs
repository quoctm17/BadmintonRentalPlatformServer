using DataAccessObject;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICourtService
    {
        Task<Result<CourtDto>> Create(CourtRequest request);
        Task<Result<CourtDto>> GetById(int id);
    }
}
