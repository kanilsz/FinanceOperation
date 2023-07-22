using MediatR;

namespace FinanceOperation.Api.Core.Features.DiscountCards.GetList;

public class GetDiscountCardListQuery : IRequest<IEnumerable<DiscountCardDto>>
{
}
