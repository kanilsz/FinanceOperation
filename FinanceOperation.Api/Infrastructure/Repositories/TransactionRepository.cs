using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Transactions;
using FinanceOperation.Infrastructure.Configs;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Linq.Expressions;

namespace FinanceOperation.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Container _container;

        private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

        private const string ContainerName = "Transactions";

        public TransactionRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
        {
            _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, ContainerName);
        }

        public async Task Create(Transaction transaction, CancellationToken cancellationToken = default)
        {
            await _container.CreateItemAsync(transaction, new(transaction.UserId), _requestOptions, cancellationToken);
        }

        public async Task Delete(string userId, string transactionId, CancellationToken cancellationToken = default)
        {
            await _container.DeleteItemAsync<Transaction>(transactionId, new(userId), _requestOptions, cancellationToken);
        }

        public async Task<IList<Transaction>> GetUserTranscations(Expression<Func<Transaction, bool>> predicate, CancellationToken cancellationToken = default)
        {
            FeedResponse<Transaction> response = await _container.GetItemLinqQueryable<Transaction>()
                .Where(predicate)
                .ToFeedIterator()
                .ReadNextAsync(cancellationToken);

            return response.ToList();
        }

        public static void Initialize(Database database)
        {
            try
            {
                database.CreateContainerIfNotExistsAsync(ContainerName, $"/{nameof(Transaction.UserId)}")
                    .GetAwaiter()
                    .GetResult();
            }
            catch
            {
            }
        }
    }
}
