using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteDiscountCards;

public class DeleteUserDiscountCardCommandHandler : IRequestHandler<DeleteUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserDiscountCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        Domain.Users.UserInfo user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

        Domain.Cards.DiscountCard discountCardToRemove = user.DiscountCards.First(c => c.CardNumber == request.CardNumber);
        _ = user.DiscountCards.Remove(discountCardToRemove);

        await _userRepository.Update(user, cancellationToken);

        return Unit.Value;
    }
}
