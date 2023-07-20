using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Infrastructure.Configs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;

namespace FinanceOperation.Infrastructure.Repositories
{
    public class BankCardRepository : IBankCardRepository
    {
        private readonly Container _container;

        private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

        private const string ContainerName = "BankCards";

        public BankCardRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
        {
            _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, ContainerName);
        }

        public async Task<BankCard> GetByCardNumber(string cardNumber, CancellationToken cancellationToken = default)
        {
            try
            {
                ItemResponse<BankCard> response = await _container.ReadItemAsync<BankCard>(cardNumber, new(cardNumber), _requestOptions, cancellationToken);
                return response.Resource;
            }
            catch (CosmosException cex) when (cex.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task<IList<BankCard>> GetBankCardsList(CancellationToken cancellationToken = default)
        {
            FeedResponse<BankCard> response = await _container.GetItemLinqQueryable<BankCard>().ToFeedIterator().ReadNextAsync(cancellationToken);
            return response.ToList();
        }

        public async Task Create(BankCard bankCard, CancellationToken cancellationToken = default)
        {
            await _container.CreateItemAsync(bankCard, new(bankCard.Id), _requestOptions, cancellationToken);
        }

        public async Task Remove(string cardNumber, CancellationToken cancellationToken = default)
        {
            await _container.DeleteItemAsync<BankCard>(cardNumber, new(cardNumber), _requestOptions, cancellationToken);
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
