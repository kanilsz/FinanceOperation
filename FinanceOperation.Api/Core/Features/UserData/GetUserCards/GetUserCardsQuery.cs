using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.GetUserCards;

public class GetUserCardsQuery : IRequest<CardsDto>
{
    public int UserId { get; set; }
}
