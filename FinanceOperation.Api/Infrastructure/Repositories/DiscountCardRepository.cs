﻿using System.Net;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using FinanceOperation.Api.Infrastructure.Configs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FinanceOperation.Api.Infrastructure.Repositories;

public class DiscountCardRepository : IDiscountCardRepository
{
    private readonly Container _container;

    private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

    private const string ContainerName = "DiscountCards";

    public DiscountCardRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
    {
        _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, ContainerName);
    }

    public async Task Create(DiscountCard discountCard)
    {
        _ = await _container.CreateItemAsync(discountCard, new(discountCard.UserId), _requestOptions);
    }

    public async Task<DiscountCard> GetByDiscountNumber(string discountCard, int userId, CancellationToken cancellationToken = default)
    {
        try
        {
            ItemResponse<DiscountCard> response = await _container.ReadItemAsync<DiscountCard>(discountCard, new(userId), _requestOptions, cancellationToken);
            return response.Resource;
        }
        catch (CosmosException cex) when (cex.StatusCode == HttpStatusCode.NotFound)
        {
            return default;
        }
    }

    public async Task<IList<DiscountCard>> GetUserDiscountCards(int userId, CancellationToken cancellationToken = default)
    {
        FeedResponse<DiscountCard> response = await _container.GetItemLinqQueryable<DiscountCard>()
            .Where(card => card.UserId == userId)
            .ToFeedIterator()
            .ReadNextAsync(cancellationToken);

        return response.ToList();
    }

    public async Task Remove(string discountCard, int userId)
    {
        _ = await _container.DeleteItemAsync<DiscountCard>(discountCard, new(userId), _requestOptions);
    }
    public static void Initialize(Database database)
    {
        try
        {
            _ = database.CreateContainerIfNotExistsAsync(ContainerName, $"/{nameof(DiscountCard.UserId)}")
                .GetAwaiter()
                .GetResult();
        }
        catch
        {
        }
    }
}
