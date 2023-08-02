using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Api.Infrastructure.Databases;
using Microsoft.Azure.Cosmos;

namespace FinanceOperation.Api.Infrastructure.Repositories;

public class DepositPropositionRepository : IDepositPropositionRepository
{
    private readonly ApplicationDbContext _context;

    public DepositPropositionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(DepositProposition depositProposition)
    {
        await _context.Deposits.AddAsync(depositProposition);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deposit = await _context.Deposits.FindAsync(id)
             ?? throw new Exception($"Unable to find the deposit with id {id}");

        deposit.IsDeleted = deposit.IsDeleted.HasValue && deposit.IsDeleted.Value
            ? throw new Exception($"Unable to delete the credit with id {id}")
            : true;

        await _context.SaveChangesAsync();
    }

    public async Task<DepositProposition> GetDeposit(int id, CancellationToken token = default)
    {
        DepositProposition  deposit = await _context.Deposits.FindAsync(new object[] { id }, cancellationToken: token)
             ?? throw new Exception($"Unable to find the deposit with id {id}");

        deposit.IsDeleted = deposit.IsDeleted.HasValue && deposit.IsDeleted.Value
            ? throw new Exception($"Unable to delete the deposit with id {id}")
            : true;

        return deposit;
    }

    public IList<DepositProposition> GetDepositList(CancellationToken token)
    {
        return _context.Deposits.ToList();
    }

    public async Task Update(DepositProposition depositProposition)
    {
        var depositToUpdate = await _context.Deposits.FindAsync(depositProposition.Id)
            ?? throw new Exception($"Unable to find the deposit with id {depositProposition.Id}");

        UpdateDepositInternal(depositToUpdate, depositProposition);
        await _context.SaveChangesAsync();

        static void UpdateDepositInternal(DepositProposition depositToUpdate, DepositProposition newDeposit)
        {
            if (depositToUpdate.UserId != newDeposit.UserId)
            {
                depositToUpdate.UserId = newDeposit.UserId;
            }
            if (newDeposit.Percentage != default && depositToUpdate.Percentage != newDeposit.Percentage)
            {
                depositToUpdate.Percentage = newDeposit.Percentage;
            }
            if (newDeposit.Summary != default && depositToUpdate.Summary != newDeposit.Summary)
            {
                depositToUpdate.Summary = newDeposit.Summary;
            }
            if (newDeposit.PropositionNumber is not null && depositToUpdate.PropositionNumber != newDeposit.PropositionNumber)
            {
                depositToUpdate.PropositionNumber = newDeposit.PropositionNumber;
            }
        }
    }
}
