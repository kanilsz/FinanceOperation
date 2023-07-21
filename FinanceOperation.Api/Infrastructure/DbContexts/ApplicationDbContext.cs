using FinanceOperation.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FinanceOperation.Infrastructure.DbContexts;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserIdentity>()
           .HasMany(e => e.Credits)
           .WithOne()
           .HasForeignKey(e=> e.UserIdentityId);

        modelBuilder.Entity<UserIdentity>()
           .HasMany(e => e.Deposits)
           .WithOne()
           .HasForeignKey(e => e.UserIdentityId);
    }

    public DbSet<UserIdentity> Users { get; set; }
}
