using DTOs;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;

namespace Repositories.Interface
{
    public interface IBadmintonCourtRepository
    {
        Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request);
    }
}
