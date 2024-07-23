using BusinessObjects;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IPaymentRepository
    {
        Task<Result<ICollection<PaymentEntity>>> GetAll();
    }
}
