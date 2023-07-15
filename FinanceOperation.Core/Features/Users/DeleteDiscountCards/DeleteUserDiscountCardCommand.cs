using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteDiscountCards;

public class DeleteUserDiscountCardCommand : IRequest
{
    public string UserId { get; set; }
    public string CardNumber { get; set; }
}
