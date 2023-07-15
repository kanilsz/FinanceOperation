using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteBankCards;

public class DeleteUserBankCardCommandHandler : IRequestHandler<DeleteUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserBankCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserBankCardCommand request, CancellationToken cancellationToken)
    {
        Domain.Users.UserInfo user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

        Domain.Cards.BankCard bankCardToRemove = user.BankCards.First(c => c.CardNumber == request.CardNumber);
        _ = user.BankCards.Remove(bankCardToRemove);

        await _userRepository.Update(user, cancellationToken);

        return Unit.Value;
    }
}
