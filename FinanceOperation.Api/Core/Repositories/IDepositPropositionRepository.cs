using FinanceOperation.Api.Domain.Propositions;

namespace FinanceOperation.Api.Core.Repositories;

public interface IDepositPropositionRepository
{
    public Task<DepositProposition> GetDeposit(int id, CancellationToken token = default);
    public IList<DepositProposition> GetDepositList(CancellationToken token = default);
    public Task Create(DepositProposition depositProposition);
    public Task Update(DepositProposition depositProposition);
    public Task Delete(int id);
}
