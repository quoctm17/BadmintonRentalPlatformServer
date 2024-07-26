using DTOs;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository; // Use repository instead of service interface
        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result<bool>> UpdateTransactionStatus(int bookingId, string status)
        {
            return await _repository.UpdateTransactionStatus(bookingId, status);
        }
    }
}
