using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteCards
{
    public class DeleteUserDiscountCardCommand: IRequest
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
    }
}
