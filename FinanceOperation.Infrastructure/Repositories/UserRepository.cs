using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using System.Net;

namespace FinanceOperation.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Container _container;

        private readonly ItemRequestOptions _requestOptions = new() { EnableContentResponseOnWrite = false };

        private const string _containerName = "Users";

        public UserRepository(CosmosClient cosmosClient, CosmosConfigs cosmosConfigs)
        {
            _container = cosmosClient.GetContainer(cosmosConfigs.DatabaseName, _containerName);
        }

        public async Task<UserInfo> GetUserInfo(string userId, CancellationToken cancellationToken = default)
        {
            try
            {
                ItemResponse<UserInfo> response = await _container.ReadItemAsync<UserInfo>(userId, new(userId), _requestOptions, cancellationToken);
                return response.Resource;
            }
            catch (CosmosException cex) when (cex.StatusCode == HttpStatusCode.NotFound)
            {
                return default;
            }
        }

        public async Task Create(UserInfo user, CancellationToken cancellationToken = default)
        {
            await _container.CreateItemAsync(user, new(user.Id), _requestOptions, cancellationToken);
        }

        public async Task<IList<UserInfo>> GetUsersInfoList(CancellationToken cancellationToken = default)
        {
            FeedResponse<UserInfo> response = await _container.GetItemLinqQueryable<UserInfo>()
                                                        .ToFeedIterator()
                                                        .ReadNextAsync(cancellationToken);
            return response.ToList();
        }

        public async Task Update(UserInfo user, CancellationToken cancellationToken = default)
        {
            await _container.ReplaceItemAsync(user, user.Id, new(user.Id), _requestOptions, cancellationToken);
        }

        public async Task Delete(string userId, CancellationToken cancellationToken = default)
        {
            await _container.DeleteItemAsync<UserInfo>(userId, new(userId), _requestOptions, cancellationToken);
        }

        internal static void Initialize(Database database)
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
