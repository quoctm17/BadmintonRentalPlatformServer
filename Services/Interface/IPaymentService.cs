using BusinessObjects;
using DTOs;
namespace Services.Interface
{
    public interface IPaymentService
    {
        Task<Result<ICollection<PaymentEntity>>> GetAll();
    }
}
