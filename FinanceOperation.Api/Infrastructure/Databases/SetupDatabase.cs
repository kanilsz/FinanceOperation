using Microsoft.EntityFrameworkCore;

namespace FinanceOperation.Api.Infrastructure.Databases;

public static class SetupDatabase
{
    public static IServiceProvider MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        return serviceProvider;
    }
}
