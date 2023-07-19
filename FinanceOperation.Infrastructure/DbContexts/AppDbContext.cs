using FinanceOperation.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FinanceOperation.Infrastructure.DbContexts;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserIdentity> Users { get; set; }
}
