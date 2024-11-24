using Microsoft.EntityFrameworkCore;
using Ntier.BSL.Services.Abstractions;
using Ntier.DAL.Contexts;
using Ntier.DAL.Models;

namespace Ntier.BSL.Services.Implements;

public class UserService : IUserService
{
    #region notes
    // Constructor that accepts DbContext via DI (dependency injection) with AddDbContext 
    #endregion
    private readonly NtierDbContext _context;
    public UserService(NtierDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        List<User> users = await _context.Users.Where(user => user.IsDeleted != true).ToListAsync();

        return users;
    }
}
