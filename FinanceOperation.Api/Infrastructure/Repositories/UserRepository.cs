using System;
using System.Net;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using FinanceOperation.Infrastructure.Configs;
using FinanceOperation.Infrastructure.DbContexts;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace FinanceOperation.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserIdentity> GetUserInfo(int userId, CancellationToken cancellationToken = default)
    {
        UserIdentity user = await _context.Users.FindAsync(userId, cancellationToken);
        return user;
        //}
    }

    public async Task Create(UserIdentity user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<UserIdentity>> GetUsersInfoList(CancellationToken cancellationToken = default)
    {
        //FeedResponse<UserIdentity> response = await _container.GetItemLinqQueryable<UserIdentity>()
        //                                            .ToFeedIterator()
        //                                            .ReadNextAsync(cancellationToken);
        //return response.ToList();
        return default;
    }

    public async Task Update(UserIdentity user)
    {
        // _ = await _container.ReplaceItemAsync(user, user.Id, new(user.Id), _requestOptions, cancellationToken);
    }

    public async Task Delete(string userId)
    {
        // _ = await _container.DeleteItemAsync<UserIdentity>(userId, new(userId), _requestOptions, cancellationToken);
    }

}
