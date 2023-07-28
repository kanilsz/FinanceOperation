using FinanceOperation.Api.Core.Features.Identity;
using FinanceOperation.Api.Domain.Users;

namespace FinanceOperation.Api.Core.Repositories;

public interface IUserRepository
{
    public Task<UserIdentity> GetUser(int id);
    public Task<int> Create(UserIdentity user);
    public Task Update(UserIdentity user);
    public Task Delete(int id);
}
