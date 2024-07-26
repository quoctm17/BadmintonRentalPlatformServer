using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ITransactionRepository
    {
        Task<Result<bool>> UpdateTransactionStatus(int bookingId, string status);
    }
}
