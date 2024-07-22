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
}