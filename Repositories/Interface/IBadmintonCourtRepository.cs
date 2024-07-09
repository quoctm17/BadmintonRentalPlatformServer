using DTOs;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.Court;

namespace Repositories.Interface
{
    public interface IBadmintonCourtRepository
    {
        Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> GetById(int id);
        Task<Result<List<BadmintonCourtDto>>> GetList();
        Task<Result<BadmintonCourtDto>> Update(UpdateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> Delete(int id);
    }
}
