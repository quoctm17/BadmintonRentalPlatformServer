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

namespace Services
{
    public class TypeOfCourtService : ITypeOfCourtService
    {
        public TypeOfCourtService()
        {

        }

        public Task<Result<TypeOfCourtDto>> Create(TypeOfCourtRequest request) => TypeOfCourtDAO.Instance.Create(request);
    }
}
