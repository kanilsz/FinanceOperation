using MediatR;

namespace FinanceOperation.Core.Features.Users.AddBankCard;

public class AddUserBankCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
