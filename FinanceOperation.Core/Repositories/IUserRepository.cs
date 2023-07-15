using FinanceOperation.Domain.Users;

namespace FinanceOperation.Core.Repositories;

public interface IUserRepository
{
    public Task<UserInfo> GetUserInfo(string userId, CancellationToken cancellationToken = default);
    public Task<IList<UserInfo>> GetUsersInfoList(CancellationToken cancellationToken = default);
    public Task Create(UserInfo user, CancellationToken cancellationToken = default);
    public Task Update(UserInfo user, CancellationToken cancellationToken = default);
    public Task Delete(string userId, CancellationToken cancellationToken = default);
}
