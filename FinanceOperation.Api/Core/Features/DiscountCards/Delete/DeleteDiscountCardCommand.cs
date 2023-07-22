using MediatR;

namespace FinanceOperation.Api.Core.Features.DiscountCards.Delete;

public class DeleteDiscountCardCommand : IRequest
{
    public string CardNumber { get; set; }
}
