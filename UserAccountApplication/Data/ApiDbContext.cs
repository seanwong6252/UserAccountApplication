using Microsoft.EntityFrameworkCore;
using UserAccountApplication.Models;

namespace UserAccountApplication.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
}
