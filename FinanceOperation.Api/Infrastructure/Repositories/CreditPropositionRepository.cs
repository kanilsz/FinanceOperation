using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Infrastructure.Databases;
using FinanceOperation.Domain.Propositions;

namespace FinanceOperation.Api.Infrastructure.Repositories;

public class CreditPropositionRepository : ICreditPropositionRepository
{
    private readonly ApplicationDbContext _context;

    public CreditPropositionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(CreditProposition creditProposition)
    {
        await _context.Credits.AddAsync(creditProposition);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var credit = await _context.Credits.FindAsync(id)
            ?? throw new Exception($"Unable to find the credit with id {id}");

        credit.IsDeleted = credit.IsDeleted.HasValue && credit.IsDeleted.Value 
            ? throw new Exception($"Unable to delete the credit with id {id}") 
            : true;

        await _context.SaveChangesAsync();
    }

    public async Task<CreditProposition> GetCredit(int id, CancellationToken token = default)
    {
        CreditProposition credit = await _context.Credits.FindAsync(new object[] { id }, cancellationToken: token)
             ?? throw new Exception($"Unable to find the credit with id {id}");

        credit.IsDeleted = credit.IsDeleted.HasValue && credit.IsDeleted.Value
            ? throw new Exception($"Unable to delete the credit with id {id}")
            : true;

        return credit;
    }

    public IList<CreditProposition> GetCreditList(CancellationToken token = default)
    {
        return _context.Credits
            .Where(c=> c.UserId == null)
            .ToList();
    }

    public async Task Update(CreditProposition creditProposition)
    {
        var creditToUpdate = await _context.Credits.FindAsync(creditProposition.Id)
             ?? throw new Exception($"Unable to find the credit with id {creditProposition.Id}");

        UpdateCreditInternal(creditToUpdate, creditProposition);
        await _context.SaveChangesAsync();

        static void UpdateCreditInternal(CreditProposition creditToUpdate, CreditProposition newCredit)
        {
            if (creditToUpdate.UserId != newCredit.UserId)
            {
                creditToUpdate.UserId = newCredit.UserId;
            }
            if (newCredit.Percentage != default && creditToUpdate.Percentage != newCredit.Percentage)
            {
                creditToUpdate.Percentage = newCredit.Percentage;
            }
            if (newCredit.Summary != default && creditToUpdate.Summary != newCredit.Summary)
            {
                creditToUpdate.Summary = newCredit.Summary;
            }
            if (newCredit.PropositionNumber is not null && creditToUpdate.PropositionNumber != newCredit.PropositionNumber)
            {
                creditToUpdate.PropositionNumber = newCredit.PropositionNumber;
            }
            if (newCredit.IsDeleted.HasValue && creditToUpdate.IsDeleted.Value != creditToUpdate.IsDeleted)
            {
                newCredit.IsDeleted = creditToUpdate.IsDeleted;
            }
        }
    }
}
