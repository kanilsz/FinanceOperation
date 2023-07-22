using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.AddBankCard;

internal class AddUserBankCardCommandHandler : IRequestHandler<AddUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;

    public AddUserBankCardCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(AddUserBankCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId, cancellationToken);

        //TODO: Fix logic
        //user.BankCards.Add(new BankCard
        //{
        //    CardNumber = request.CardNumber,
        //    Balance = request.Balance
        //});

        await _userRepository.Update(user);
        return Unit.Value;
    }
}
