using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteDiscountCards;

public class DeleteUserDiscountCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
}
