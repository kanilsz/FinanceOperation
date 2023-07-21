using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.AddDiscountCard;

public class AddUserDiscountCardCommandHandler : IRequestHandler<AddUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;

    public AddUserDiscountCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(AddUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

        // TODO Fix logic
        //user.DiscountCards.Add(new DiscountCard
        //{
        //    CardNumber = request.CardNumber,
        //    Balance = request.Balance
        //});

        await _userRepository.Update(user);
        return Unit.Value;
    }
}
