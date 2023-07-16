using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.GetByDiscountNumber;

public class GetByDiscountNumberQuery : IRequest<DiscountCardDto>
{
    public string CardNumber { get; set; }
}
