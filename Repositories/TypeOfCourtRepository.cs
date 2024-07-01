using DataAccessObject;
using DTOs;
using DTOs.Request.TypeOfCourt;
using DTOs.Response.TypeOfCourt;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TypeOfCourtRepository : ITypeOfCourtRepository
    {
        public TypeOfCourtRepository()
        {

        }

        public Task<Result<TypeOfCourtDto>> Create(TypeOfCourtRequest request) => TypeOfCourtDAO.Instance.Create(request);
    }
}
