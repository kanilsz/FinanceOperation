using FinanceOperation.Api.Domain.Users;

namespace FinanceOperation.Api.Core.Repositories;

public interface IUserRepository
{
    public Task<UserIdentity> GetUser(int userId);
    public Task<IList<UserIdentity>> GetUsersInfoList(CancellationToken cancellationToken = default);
    public Task Create(UserIdentity user);
    public Task Update(UserIdentity user);
    public Task Delete(string userId);
}
