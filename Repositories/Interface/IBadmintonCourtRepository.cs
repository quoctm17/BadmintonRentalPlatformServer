using DTOs;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.Page;

namespace Repositories.Interface
{
    public interface IBadmintonCourtRepository
    {
        Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> GetById(int id);
        Task<Result<PagedResult<BadmintonCourtDto>>> GetPaging(int page, int size);
        Task<Result<List<BadmintonCourtDto>>> GetList();
        Task<Result<BadmintonCourtDto>> Update(UpdateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> Delete(int id);
    }
}
