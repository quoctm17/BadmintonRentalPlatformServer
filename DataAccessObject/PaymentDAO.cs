using BusinessObjects;
using DTOs;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public class PaymentDAO
    {
        private readonly AppDbContext _context;
        private static PaymentDAO instance;

        public PaymentDAO()
        {
            _context = new AppDbContext();
        }

        public static PaymentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PaymentDAO();
                }
                return instance;
            }
        }

        public async Task<Result<ICollection<PaymentEntity>>> GetAll()
        {
            try
            {
                ICollection<PaymentEntity> payments = await _context.Payments.AsNoTracking().ToListAsync();
                return new Result<ICollection<PaymentEntity>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = payments
                };
            }
            catch (Exception ex)
            {
                return new Result<ICollection<PaymentEntity>>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message
                };
            }
        }
    }
}
