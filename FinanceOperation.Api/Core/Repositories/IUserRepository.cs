using FinanceOperation.Domain.Users;

namespace FinanceOperation.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<UserIdentity> GetUserInfo(int userId, CancellationToken cancellationToken = default);
        public Task<IList<UserIdentity>> GetUsersInfoList(CancellationToken cancellationToken = default);
        public Task Create(UserIdentity user);
        public Task Update(UserIdentity user);
        public Task Delete(string userId);
    }
}
