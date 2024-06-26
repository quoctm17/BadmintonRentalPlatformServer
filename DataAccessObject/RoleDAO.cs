using BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject;

public class RoleDAO
{
    private readonly AppDbContext _context;
    private static RoleDAO instance;
    
    public RoleDAO()
    {
        _context = new AppDbContext();
    }

    public static RoleDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RoleDAO();
            }
            return instance;
        }
    }

    public async Task<RoleEntity?> GetRoleName(string roleName)
    {
        return await _context.Roles.SingleOrDefaultAsync(x => x.RoleName.Equals(roleName));
    }
}