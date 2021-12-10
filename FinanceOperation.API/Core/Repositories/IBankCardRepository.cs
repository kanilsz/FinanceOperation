using FinanceOperation.API.Domain.Cards;

namespace FinanceOperation.API.Core.Repositories
{
    public interface IBankCardRepository
    {
        public Task<BankCard> GetByCardNumber(string cardNumber, CancellationToken cancellationToken = default);
        public Task<IList<BankCard>> GetBankCardsList(CancellationToken cancellationToken = default);
        public Task Create(BankCard bankCard, CancellationToken cancellationToken = default);
    }
}
