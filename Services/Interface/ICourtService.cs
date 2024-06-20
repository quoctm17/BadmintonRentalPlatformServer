using DataAccessObject;
using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using BusinessObjects;

namespace Services.Interface
{
    public interface ICourtService
    {
        Task<Result<CourtDto>> Create(CourtRequest request);
        Task<Result<CourtDto>> GetById(int id);
        Task<Result<List<CourtDetailDto>>> GetCourtsByBadmintonCourtId(int badmintonCourtId);
    }
}
