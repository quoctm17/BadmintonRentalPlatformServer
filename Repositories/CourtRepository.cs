using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using Repositories.Interface;
using DataAccessObject;
using BusinessObjects;

namespace Repositories
{
    public class CourtRepository : ICourtRepository
    {
        public CourtRepository() { }

        public Task<Result<CourtDto>> Create(CourtRequest request) => CourtDAO.Instance.Create(request);
        public Task<Result<CourtDto>> GetById(int id) => CourtDAO.Instance.GetById(id);
        public Task<Result<List<CourtDetailDto>>> GetCourtsByBadmintonCourtId(int badmintonCourtId) => CourtDAO.Instance.GetCourtsByBadmintonCourtId(badmintonCourtId);
    }
}
