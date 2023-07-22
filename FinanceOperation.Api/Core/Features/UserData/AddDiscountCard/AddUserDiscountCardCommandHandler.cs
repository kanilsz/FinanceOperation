using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.AddDiscountCard;

public class AddUserDiscountCardCommandHandler : IRequestHandler<AddUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;

    public AddUserDiscountCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(AddUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId, cancellationToken);

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
