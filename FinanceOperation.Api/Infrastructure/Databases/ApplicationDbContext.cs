using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Domain.Propositions;
using Microsoft.EntityFrameworkCore;

namespace FinanceOperation.Api.Infrastructure.Databases;
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
          .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<UserIdentity>()
          .HasMany(e => e.Deposits)
          .WithOne()
          .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<UserIdentity>()
            .HasData(
            new UserIdentity()
            {
                Id = 1,
                Email = "kon@gmail.com",
                Password = "password",
                SecondName = "Konotop",
                FirstName = "Maksym",
            });

        modelBuilder.Entity<CreditProposition>()
            .HasData(
            new List<CreditProposition>(2)
            {
                new CreditProposition()
                    {
                        Id = 1,
                        UserId = null,
                        StartDateTime = default,
                        EndDateTime = default,
                        Percentage = 1000,
                        Summary = 1000,
                        IsDeleted = false,
                        PropositionNumber = Guid.NewGuid().ToString(),
                    },
                new CreditProposition()
                    {
                        Id = 2,
                        UserId = 1,
                        StartDateTime = DateTime.UtcNow,
                        EndDateTime = DateTime.UtcNow,
                        Percentage = 102,
                        Summary = 10001,
                        IsDeleted = false,
                        PropositionNumber = Guid.NewGuid().ToString(),
                    }
            });

        modelBuilder.Entity<DepositProposition>()
            .HasData(
            new List<DepositProposition>(2)
            {
                new DepositProposition()
                    {
                        Id = 1,
                        UserId = 1,
                        StartDateTime = DateTime.UtcNow,
                        EndDateTime = DateTime.UtcNow,
                        Percentage = 1000,
                        Summary = 1000,
                        IsDeleted = false,
                        PropositionNumber = Guid.NewGuid().ToString(),
                    },
                new DepositProposition()
                    {
                        Id = 2,
                        UserId = null,
                        StartDateTime = default,
                        EndDateTime = default,
                        Percentage = 102,
                        Summary = 10001,
                        IsDeleted = false,
                        PropositionNumber = Guid.NewGuid().ToString(),
                    }
            });
    }

    public DbSet<UserIdentity> Users { get; set; }
    public DbSet<CreditProposition> Credits { get; set; }
    public DbSet<DepositProposition> Deposits { get; set; }
}
