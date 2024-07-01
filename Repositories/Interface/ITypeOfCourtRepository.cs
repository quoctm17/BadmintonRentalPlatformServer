using DTOs;
using DTOs.Request.TypeOfCourt;
using DTOs.Response.TypeOfCourt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ITypeOfCourtRepository
    {
        Task<Result<TypeOfCourtDto>> Create(TypeOfCourtRequest request);
    }
}
