using Microsoft.EntityFrameworkCore;
using Ntier.DAL.Models;

namespace Ntier.DAL.Contexts;

public class NtierDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public NtierDbContext(DbContextOptions<NtierDbContext> opt) : base(opt)
    {
        
    }
}
