using FinanceOperation.Api.Domain.Cards;

namespace FinanceOperation.Api.Core.Repositories;

public interface IBankCardRepository
{
    public Task<BankCard> GetByCardNumber(string cardNumber, int userId, CancellationToken cancellationToken = default);
    public Task<IList<BankCard>> GetUserBankCards(int userId, CancellationToken cancellationToken = default);
    public Task Create(BankCard bankCard);
    public Task Remove(string cardNumber, int userId);
}
