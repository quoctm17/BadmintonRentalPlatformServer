using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;

namespace Repositories.Interface
{
    public interface ICourtRepository
    {
        Task<Result<CourtDto>> Create(CourtRequest request);
        Task<Result<CourtDto>> GetById(int id);
        Task<Result<List<CourtDetailDto>>> GetCourtsByBadmintonCourtId(int badmintonCourtId);
    }
}
