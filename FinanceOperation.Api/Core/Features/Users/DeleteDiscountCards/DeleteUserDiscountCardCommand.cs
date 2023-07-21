using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteDiscountCards;

public class DeleteUserDiscountCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
}
