using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Infrastructure.Configs;
using FinanceOperation.Api.Infrastructure.Databases;
using FinanceOperation.Api.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace FinanceOperation.Api.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {
        services.InitializeCosmosDb(configuration)
                .InitializeMsSqlDb(configuration);

        services.AddTransient<IBankCardRepository, BankCardRepository>()
                .AddTransient<IDiscountCardRepository, DiscountCardRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ITransactionRepository, TransactionRepository>()
                .AddTransient<IDepositPropositionRepository, DepositPropositionRepository>()
                .AddTransient<ICreditPropositionRepository, CreditPropositionRepository>();

        return services;
    }

    private static IServiceCollection InitializeCosmosDb(this IServiceCollection services, IConfiguration configuration)
    {
        CosmosConfigs cosmosConfigs = configuration.GetSection("CosmosDb").Get<CosmosConfigs>();
        services.AddSingleton(cosmosConfigs);

        CosmosClient client = new(cosmosConfigs.ConnectionString);

        Database database = cosmosConfigs.Throughput > 0
            ? client.CreateDatabaseIfNotExistsAsync(cosmosConfigs.DatabaseName, cosmosConfigs.Throughput).GetAwaiter().GetResult()
            : client.CreateDatabaseIfNotExistsAsync(cosmosConfigs.DatabaseName).GetAwaiter().GetResult();

        BankCardRepository.Initialize(database);
        DiscountCardRepository.Initialize(database);
        TransactionRepository.Initialize(database);

        services.AddSingleton(client);

        return services;
    }

    private static IServiceCollection InitializeMsSqlDb(this IServiceCollection services, IConfiguration configuration)
    {
        MsSqlConfigs cosmosConfigs = configuration.GetSection("MsSql").Get<MsSqlConfigs>();

        services.AddDbContext<ApplicationDbContext>(
           options => options.UseSqlServer(cosmosConfigs.ConnectionString));

        return services;
    }
}
