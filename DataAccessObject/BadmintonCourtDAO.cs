using BusinessObjects;

namespace DataAccessObject;

public class BadmintonCourtDAO
{
    private readonly AppDbContext _context;
    private static BadmintonCourtDAO instance;
    
    public BadmintonCourtDAO()
    {
        _context = new AppDbContext();
    }

    public static BadmintonCourtDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BadmintonCourtDAO();
            }
            return instance;
        }
    }

    public async Task<int> CreateNewBadmintonCourt(BadmintonCourtEntity badmintonCourtEntity)
    {
        await _context.BadmintonCourts.AddAsync(badmintonCourtEntity);
        return await _context.SaveChangesAsync();
    }
}