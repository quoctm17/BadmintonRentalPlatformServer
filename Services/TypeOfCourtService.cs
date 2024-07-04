using DataAccessObject;
using DTOs.Request.TypeOfCourt;
using DTOs.Response.TypeOfCourt;
using DTOs;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interface;

namespace Services
{
    public class TypeOfCourtService : ITypeOfCourtService
    {
        private readonly ITypeOfCourtRepository _repository;
        public TypeOfCourtService(ITypeOfCourtRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<TypeOfCourtDto>> Create(TypeOfCourtRequest request) => TypeOfCourtDAO.Instance.Create(request);
    }
}
