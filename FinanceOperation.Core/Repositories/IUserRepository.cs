using FinanceOperation.Domain.Users;

namespace FinanceOperation.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<UserInfo> GetUserInfoList(string userId, CancellationToken cancellationToken = default);
        public Task Create(UserInfo user, CancellationToken cancellationToken = default);
    }
}
