﻿using FinanceOperation.API.Core;
using FinanceOperation.API.Core.Repositories;
using FinanceOperation.API.Infrastucture.Repositories;
using Microsoft.Azure.Cosmos;

namespace FinanceOperation.API.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCore();

            services.InitializeCosmosDb(configuration);

            services.AddTransient<IBankCardRepository, BankCardRepository>();

            return services;
        }

        private static void InitializeCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            CosmosConfigs cosmosConfigs = configuration.GetSection("CosmosDb").Get<CosmosConfigs>();
            services.AddSingleton(cosmosConfigs);

            var client = new CosmosClient(cosmosConfigs.ConnectionString);

            Database database = cosmosConfigs.Throughput > 0
                ? client.CreateDatabaseIfNotExistsAsync(cosmosConfigs.DatabaseName, cosmosConfigs.Throughput).GetAwaiter().GetResult()
                : client.CreateDatabaseIfNotExistsAsync(cosmosConfigs.DatabaseName).GetAwaiter().GetResult();

            BankCardRepository.Initialize(database);

            services.AddSingleton(client);
        }
    }
}
