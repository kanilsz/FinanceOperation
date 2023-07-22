using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteDiscountCards;

public class DeleteUserDiscountCardCommandHandler : IRequestHandler<DeleteUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserDiscountCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId, cancellationToken);

        // TODO Fix logic
        //DiscountCard discountCardToRemove = user.DiscountCards.First(c => c.CardNumber == request.CardNumber);
        //user.DiscountCards.Remove(discountCardToRemove);

        await _userRepository.Update(user);

        return Unit.Value;
    }
}
