using FinanceOperation.API.Core.Repositories;
using FinanceOperation.API.Domain.Cards;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;

namespace FinanceOperation.API.Infrastucture.Repositories
{
    public class BankCardRepository : IBankCardRepository
    {
        private readonly Container _container;

        private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

        private const string _containerName = "BankCards";

        public BankCardRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
        {
            _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, _containerName);
        }

        public async Task<BankCard?> GetByCardNumber(string cardNumber, CancellationToken cancellationToken = default)
        {
            try
            {
                ItemResponse<BankCard> response = await _container.ReadItemAsync<BankCard>(cardNumber, new(cardNumber), _requestOptions, cancellationToken);
                return response.Resource;
            }
            catch (CosmosException ce) when (ce.StatusCode == HttpStatusCode.NotFound)
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
            bankCard.CreatedAtUtc = DateTime.UtcNow;
            await _container.CreateItemAsync(bankCard, new(bankCard.Id), _requestOptions, cancellationToken);
        }

        public static void Initialize(Database database)
        {
            try
            {
                database.CreateContainerIfNotExistsAsync(_containerName, "/id")
                    .GetAwaiter()
                    .GetResult();
            }
            catch
            {
            }

        }
    }
}
