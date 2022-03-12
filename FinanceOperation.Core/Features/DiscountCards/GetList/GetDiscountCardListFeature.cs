using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.GetList
{
    public class GetDiscountCardListFeature : IRequest<IEnumerable<DiscountCardDto>>
    {
    }
}
