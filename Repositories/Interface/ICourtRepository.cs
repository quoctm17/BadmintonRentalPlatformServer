using DTOs.Request.Court;
using DTOs.Response.Court;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICourtRepository
    {
        Task<Result<CourtDto>> Create(CourtRequest request);
    }
}
