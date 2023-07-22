using MediatR;

namespace FinanceOperation.Api.Core.Features.DiscountCards.GetByDiscountNumber;

public class GetByDiscountNumberQuery : IRequest<DiscountCardDto>
{
    public string CardNumber { get; set; }
}
