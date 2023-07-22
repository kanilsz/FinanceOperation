using FinanceOperation.Api.Domain.Cards;

namespace FinanceOperation.Api.Core.Repositories;

public interface IDiscountCardRepository
{
    public Task<DiscountCard> GetByDiscountNumber(string discountCard, int userId, CancellationToken cancellationToken = default);
    public Task<IList<DiscountCard>> GetUserDiscountCards(int userId, CancellationToken cancellationToken = default);
    public Task Create(DiscountCard discountCard);
    public Task Remove(string discountCard, int userId);
}
