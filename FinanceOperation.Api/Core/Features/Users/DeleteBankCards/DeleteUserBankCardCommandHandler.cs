using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Users;
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
        UserIdentity user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

        // TODO Fix logic
        //BankCard bankCardToRemove = user.BankCards.First(c => c.CardNumber == request.CardNumber);
        //user.BankCards.Remove(bankCardToRemove);

        await _userRepository.Update(user, cancellationToken);

        return Unit.Value;
    }
}
