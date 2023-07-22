using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Api.Infrastructure.DbContexts;

namespace FinanceOperation.Api.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserIdentity> GetUser(int userId)
    {
        UserIdentity user;
        try
        {
            user = await _context.Users.FindAsync(userId);
        }
        catch
        {
            return default;
        }
        return user;
    }

    public async Task Create(UserIdentity user)
    {
        _ = await _context.Users.AddAsync(user);
        _ = await _context.SaveChangesAsync();
    }

    public IList<UserIdentity> GetUsersInfoList(CancellationToken cancellationToken = default)
    {
        //FeedResponse<UserIdentity> response = await _container.GetItemLinqQueryable<UserIdentity>()
        //                                            .ToFeedIterator()
        //                                            .ReadNextAsync(cancellationToken);
        //return response.ToList();
        return default;
    }

    public void Update(UserIdentity user)
    {
        // _ = await _container.ReplaceItemAsync(user, user.Id, new(user.Id), _requestOptions, cancellationToken);
    }

    public void Delete(string userId)
    {
        // _ = await _container.DeleteItemAsync<UserIdentity>(userId, new(userId), _requestOptions, cancellationToken);
    }

    Task<IList<UserIdentity>> IUserRepository.GetUsersInfoList(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task IUserRepository.Update(UserIdentity user)
    {
        throw new NotImplementedException();
    }

    Task IUserRepository.Delete(string userId)
    {
        throw new NotImplementedException();
    }
}
