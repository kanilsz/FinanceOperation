using FinanceOperation.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FinanceOperation.Infrastructure.DbContexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserIdentity> Users { get; set; }
}
