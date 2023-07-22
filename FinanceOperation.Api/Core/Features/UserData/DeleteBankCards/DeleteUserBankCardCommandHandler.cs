using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteBankCards;

public class DeleteUserBankCardCommandHandler : IRequestHandler<DeleteUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserBankCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserBankCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId, cancellationToken);

        // TODO Fix logic
        //BankCard bankCardToRemove = user.BankCards.First(c => c.CardNumber == request.CardNumber);
        //user.BankCards.Remove(bankCardToRemove);

        await _userRepository.Update(user);

        return Unit.Value;
    }
}
