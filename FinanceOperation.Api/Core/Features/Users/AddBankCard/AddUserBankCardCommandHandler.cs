using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Users;
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
        UserIdentity user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

        //TODO: Fix logic
        //user.BankCards.Add(new BankCard
        //{
        //    CardNumber = request.CardNumber,
        //    Balance = request.Balance
        //});

        await _userRepository.Update(user, cancellationToken);
        return Unit.Value;
    }
}
