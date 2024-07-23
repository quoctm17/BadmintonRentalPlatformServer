using BusinessObjects;
using DataAccessObject;
using DTOs;
using Repositories.Interface;

namespace Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public async Task<Result<ICollection<PaymentEntity>>> GetAll()
        {
            return await PaymentDAO.Instance.GetAll();
        }
    }
}
