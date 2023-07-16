using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.Users.AddBankCard;

internal class AddUserBankCardCommandHandler : IRequestHandler<AddUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;

    public AddUserBankCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(AddUserBankCardCommand request, CancellationToken cancellationToken)
    {
        Domain.Users.UserInfo user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

        user.BankCards.Add(new BankCard
        {
            CardNumber = request.CardNumber,
            Balance = request.Balance
        });

        await _userRepository.Update(user, cancellationToken);
        return Unit.Value;
    }
}
