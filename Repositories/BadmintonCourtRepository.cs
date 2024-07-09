using AutoMapper;
using BusinessObjects;
using BusinessObjects.Constants;
using DataAccessObject;
using DTOs;
using DTOs.Request.BadmintonCourt;
using DTOs.Response.BadmintonCourt;
using Repositories.Interface;
using System.Net;

namespace Repositories
{
    public class BadmintonCourtRepository : IBadmintonCourtRepository
    {
        public BadmintonCourtRepository()
        {
        }

        public Task<Result<BadmintonCourtDto>> Create(CreateBadmintonCourtRequest request) => BadmintonCourtDAO.Instance.Create(request);

        public Task<Result<BadmintonCourtDto>> Delete(int id) => BadmintonCourtDAO.Instance.Delete(id);

        public Task<Result<BadmintonCourtDto>> GetById(int id) => BadmintonCourtDAO.Instance.GetById(id);

        public Task<Result<BadmintonCourtDto>> Update(UpdateBadmintonCourtRequest request) => BadmintonCourtDAO.Instance.Update(request);

        Task<Result<List<BadmintonCourtDto>>> IBadmintonCourtRepository.GetList() => BadmintonCourtDAO.Instance.GetList();
    }
}
