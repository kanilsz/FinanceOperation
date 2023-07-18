using FinanceOperation.Core.Repositories;
using FinanceOperation.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceOperation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
    {
        services.InitializeCosmosDb(configuration);

        services.AddTransient<IBankCardRepository, BankCardRepository>()
                .AddTransient<IDiscountCardRepository, DiscountCardRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ITransactionRepository, TransactionRepository>();

        return services;
    }

    private static void InitializeCosmosDb(this IServiceCollection services, IConfiguration configuration)
    {
        CosmosConfigs cosmosConfigs = configuration.GetSection("CosmosDb").Get<CosmosConfigs>();
        services.AddSingleton(cosmosConfigs);

        CosmosClient client = new(cosmosConfigs.ConnectionString);

        Database database = cosmosConfigs.Throughput > 0
            ? client.CreateDatabaseIfNotExistsAsync(cosmosConfigs.DatabaseName, cosmosConfigs.Throughput).GetAwaiter().GetResult()
            : client.CreateDatabaseIfNotExistsAsync(cosmosConfigs.DatabaseName).GetAwaiter().GetResult();

        BankCardRepository.Initialize(database);
        DiscountCardRepository.Initialize(database);
        UserRepository.Initialize(database);
        TransactionRepository.Initialize(database);

        services.AddSingleton(client);
    }
}
