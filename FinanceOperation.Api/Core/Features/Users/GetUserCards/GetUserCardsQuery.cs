using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserCards;

public class GetUserCardsQuery : IRequest<CardsDto>
{
    public string UserId { get; set; }
}
