using BusinessObjects;
using DTOs;
using Repositories.Interface;
using Services.Interface;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<ICollection<PaymentEntity>>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
