using FinanceOperation.Domain.Propositions;

namespace FinanceOperation.Api.Core.Repositories;

public interface ICreditPropositionRepository
{
    public Task<CreditProposition> GetCredit(int id, CancellationToken cancellationToken = default);
    public IList<CreditProposition> GetCreditList(CancellationToken cancellationToken = default);
    public Task Create(CreditProposition proposition);
    public Task Update(CreditProposition proposition);
    public Task Delete(int id);
}
