using DTOs.Request.BadmintonCourt;
using DTOs;
using DTOs.Response.BadmintonCourt;
using DTOs.Response.Page;

namespace Services.Interface
{
    public interface IBadmintonCourtService
    {
        Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> GetById(int id);
        Task<Result<List<BadmintonCourtDto>>> GetList();
        Task<Result<PagedResult<BadmintonCourtDto>>> GetPaging(int page, int size);
        Task<Result<BadmintonCourtDto>> Update(UpdateBadmintonCourtRequest request);
        Task<Result<BadmintonCourtDto>> Delete(int id);
    }
}
