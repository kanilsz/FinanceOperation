using FinanceOperation.Api.Domain.Cards;

namespace FinanceOperation.Api.Core.Repositories;

public interface IDiscountCardRepository
{
    public Task<DiscountCard> GetByDiscountNumber(string discountCard, CancellationToken cancellationToken = default);
    public Task<IList<DiscountCard>> GetDiscountCardsList(CancellationToken cancellationToken = default);
    public Task Create(DiscountCard discountCard, CancellationToken cancellationToken = default);
    public Task Remove(string discountCard, CancellationToken cancellationToken = default);
}
