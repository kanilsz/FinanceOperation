
using System.Linq.Expressions;
using FinanceOperation.Domain.Transactions;

namespace FinanceOperation.Core.Repositories;

public interface ITransactionRepository
{
    public Task<IList<Transaction>> GetUserTranscations(Expression<Func<Transaction, bool>> predicate, CancellationToken cancellationToken = default);
    public Task Create(Transaction transaction, CancellationToken cancellationToken = default);
    public Task Delete(string userId, string transactionId, CancellationToken cancellationToken = default);
}
