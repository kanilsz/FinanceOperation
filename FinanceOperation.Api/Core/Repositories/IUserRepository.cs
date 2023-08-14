using System.Linq.Expressions;
using FinanceOperation.Api.Domain.Users;

namespace FinanceOperation.Api.Core.Repositories;

public interface IUserRepository
{
    public Task<UserIdentity> GetUserBy(Expression<Func<UserIdentity, bool>> predicate);
    public Task<int> Create(UserIdentity user);
    public Task Update(UserIdentity user);
    public Task Delete(int id);
}
