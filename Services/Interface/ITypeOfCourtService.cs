using DTOs.Request.TypeOfCourt;
using DTOs.Response.TypeOfCourt;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ITypeOfCourtService
    {
        Task<Result<TypeOfCourtDto>> Create(TypeOfCourtRequest request);
    }
}
