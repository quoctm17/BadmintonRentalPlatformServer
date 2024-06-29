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
    }
}
