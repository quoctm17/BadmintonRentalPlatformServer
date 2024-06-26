using System.Net;
using BusinessObjects;
using BusinessObjects.Constants;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject;

public class UserDAO
{
    private readonly AppDbContext _context;
    private static UserDAO instance;
    
    public UserDAO()
    {
        _context = new AppDbContext();
    }

    public static UserDAO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }
            return instance;
        }
    }
    
    public async Task<UserEntity?> LoginOwner(string email, string password)
    {
        return await _context.Users.
            Include(user => user.UserRoles)
            .ThenInclude(role => role.Role)
            .SingleOrDefaultAsync(user => user.Email.Equals(email) && 
                                          user.Password.Equals(password) && 
                                          user.UserRoles.Any(role => role.Role.RoleName.Equals("Owner")));
    }
    
    public async Task<UserEntity?> LoginPlayer(string email, string password)
    {
        return await _context.Users.
            Include(user => user.UserRoles)
            .ThenInclude(role => role.Role)
            .SingleOrDefaultAsync(user => user.Email.Equals(email) && 
                                          user.Password.Equals(password) && 
                                          user.UserRoles.Any(role => role.Role.RoleName.Equals("Player")));
    }

    public async Task<int> AddNewUser(UserEntity user)
    {
        await _context.Users.AddAsync(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<UserEntity>> GetUserByEmail(string email)
    {
        return await _context.Users
            .Where(user => user.Email.Equals(email))
            .ToListAsync();
    }
}