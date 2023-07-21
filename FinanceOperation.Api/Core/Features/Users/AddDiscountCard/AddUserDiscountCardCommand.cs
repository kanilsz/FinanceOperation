using MediatR;

namespace FinanceOperation.Core.Features.Users.AddDiscountCard;

public class AddUserDiscountCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
