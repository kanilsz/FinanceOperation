using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteBankCards;

public class DeleteUserBankCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
}
