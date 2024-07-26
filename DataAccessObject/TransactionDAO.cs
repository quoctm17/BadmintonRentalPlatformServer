using BusinessObjects;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccessObject
{
    public class TransactionDAO
    {
        private readonly AppDbContext _context;
        private static TransactionDAO instance;

        public TransactionDAO()
        {
            _context = new AppDbContext();
        }

        public static TransactionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TransactionDAO();
                }
                return instance;
            }
        }

        public async Task<Result<bool>> Create(TransactionEntity transaction)
        {
            try
            {
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message
                };
            }
        }

        public async Task<Result<bool>> UpdateTransactionStatus(int bookingId, string status)
        {
            try
            {
                var transaction = await _context.Transactions
                    .FirstOrDefaultAsync(t => t.BookingReservationId == bookingId);
                if (transaction == null)
                {
                    return new Result<bool>
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "Transaction not found",
                        Data = false
                    };
                }

                transaction.Status = status;
                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Data = false
                };
            }
        }

    }
}
