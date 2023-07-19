using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Infrastructure.Configs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;

namespace FinanceOperation.Infrastructure.Repositories
{
    public class DiscountCardRepository : IDiscountCardRepository
    {
        private readonly Container _container;

        private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

        private const string ContainerName = "DiscountCards";

        public DiscountCardRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
        {
            _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, ContainerName);
        }

        public async Task Create(DiscountCard discountCard, CancellationToken cancellationToken = default)
        {
            await _container.CreateItemAsync(discountCard, new(discountCard.Id), _requestOptions, cancellationToken);
        }

        public async Task<DiscountCard> GetByDiscountNumber(string discountCard, CancellationToken cancellationToken = default)
        {
            try
            {
                ItemResponse<DiscountCard> response = await _container.ReadItemAsync<DiscountCard>(discountCard, new(discountCard), _requestOptions, cancellationToken);
                return response.Resource;
            }
            catch (CosmosException cex) when (cex.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<IList<DiscountCard>> GetDiscountCardsList(CancellationToken cancellationToken = default)
        {
            FeedResponse<DiscountCard> response = await _container.GetItemLinqQueryable<DiscountCard>().ToFeedIterator().ReadNextAsync(cancellationToken);
            return response.ToList();
        }

        public async Task Remove(string discountCard, CancellationToken cancellationToken = default)
        {
            await _container.DeleteItemAsync<DiscountCard>(discountCard, new(discountCard), _requestOptions, cancellationToken);
        }
        public static void Initialize(Database database)
        {
            try
            {
                database.CreateContainerIfNotExistsAsync(ContainerName, "/id")
                    .GetAwaiter()
                    .GetResult();
            }
            catch
            {
            }
        }
    }
}
