using DTOs.Request.BadmintonCourt;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Response.BadmintonCourt;

namespace Services.Interface
{
    public interface IBadmintonCourtService
    {
        Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> GetById(int id);
        Task<Result<List<BadmintonCourtDto>>> GetList();
    }
}
