using DataAccessObject;
using DTOs;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<Result<bool>> UpdateTransactionStatus(int bookingId, string status)
        {
            return await TransactionDAO.Instance.UpdateTransactionStatus(bookingId, status);
        }
    }
}
