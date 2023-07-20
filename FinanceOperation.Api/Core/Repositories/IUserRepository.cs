using FinanceOperation.Domain.Users;

namespace FinanceOperation.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<UserIdentity> GetUserInfo(string userId, CancellationToken cancellationToken = default);
        public Task<IList<UserIdentity>> GetUsersInfoList(CancellationToken cancellationToken = default);
        public Task Create(UserIdentity user, CancellationToken cancellationToken = default);
        public Task Update(UserIdentity user, CancellationToken cancellationToken = default);
        public Task Delete(string userId, CancellationToken cancellationToken = default);
    }
}
