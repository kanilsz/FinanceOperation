using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteBankCards;

public class DeleteUserBankCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
}
