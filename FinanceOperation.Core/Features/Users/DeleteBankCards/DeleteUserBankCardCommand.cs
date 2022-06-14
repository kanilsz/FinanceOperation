using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteCards
{
    public class DeleteUserBankCardCommand: IRequest
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
    }
}
