using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject;

public class BookingDetailDAO
{
    private readonly AppDbContext _context;
    private static BookingDetailDAO instance;

    public BookingDetailDAO()
    {
        _context = new AppDbContext();
    }

    public static BookingDetailDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BookingDetailDAO();
            }
            return instance;
        }
    }

    public async Task<List<BookingDetailEntity>> GetAllBookingDetails()
    {
        return await _context.BookingDetails.ToListAsync();
    }

    public async Task<List<BookingDetailEntity>> GetBookingDetailsByReservationId(int bookingReservationId)
    {
        return await _context.BookingDetails
            .Where(b => b.BookingId == bookingReservationId)
            .Include(b => b.CourtEntity)
            .Select(b => new BookingDetailEntity
            {
                Id = b.Id,
                BookingId = b.BookingId,
                CourtId = b.CourtId,
                Price = b.Price,
                CourtEntity = new CourtEntity
                {
                    Id = b.CourtEntity.Id,
                    CourtCode = b.CourtEntity.CourtCode,
                    TypeOfCourtId = b.CourtEntity.TypeOfCourtId,
                    BadmintonCourtId = b.CourtEntity.BadmintonCourtId,
                    Price = b.CourtEntity.Price,
                    CourtImage = b.CourtEntity.CourtImage
                }
            })
            .ToListAsync();
    }
}