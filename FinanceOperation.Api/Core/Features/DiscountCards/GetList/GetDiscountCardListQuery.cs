using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.GetList;

public class GetDiscountCardListQuery : IRequest<IEnumerable<DiscountCardDto>>
{
}
