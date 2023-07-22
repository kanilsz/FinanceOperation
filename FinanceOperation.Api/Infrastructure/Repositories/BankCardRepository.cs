using System.Net;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using FinanceOperation.Api.Infrastructure.Configs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FinanceOperation.Api.Infrastructure.Repositories;

public class BankCardRepository : IBankCardRepository
{
    private readonly Container _container;

    private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

    private const string ContainerName = "BankCards";

    public BankCardRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
    {
        _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, ContainerName);
    }

    public async Task<BankCard> GetByCardNumber(string cardNumber, int userId, CancellationToken cancellationToken = default)
    {
        try
        {
            ItemResponse<BankCard> response = await _container.ReadItemAsync<BankCard>(cardNumber, new(userId), _requestOptions, cancellationToken);
            return response.Resource;
        }
        catch (CosmosException cex) when (cex.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }
    }

    public async Task<IList<BankCard>> GetUserBankCards(int userId, CancellationToken cancellationToken = default)
    {
        FeedResponse<BankCard> response = await _container.GetItemLinqQueryable<BankCard>()
            .Where(card=> card.UserId == userId)
            .ToFeedIterator()
            .ReadNextAsync(cancellationToken);

        return response.ToList();
    }

    public async Task Create(BankCard bankCard)
    {
        _ = await _container.CreateItemAsync(bankCard, new(bankCard.UserId), _requestOptions);
    }

    public async Task Remove(string cardNumber, int userId)
    {
        _ = await _container.DeleteItemAsync<BankCard>(cardNumber, new(userId), _requestOptions);
    }

    public static void Initialize(Database database)
    {
        try
        {
            database.CreateContainerIfNotExistsAsync(ContainerName, $"/{nameof(BankCard.UserId)}")
               .GetAwaiter()
               .GetResult();
        }
        catch
        {
        }
    }
}
