using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.Delete;

public class DeleteDiscountCardCommand : IRequest
{
    public string CardNumber { get; set; }
}
