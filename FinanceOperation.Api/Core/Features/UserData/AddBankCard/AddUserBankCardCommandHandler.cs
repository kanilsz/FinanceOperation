using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.AddBankCard;

internal class AddUserBankCardCommandHandler : IRequestHandler<AddUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IBankCardRepository _bankCardRepository;

    public AddUserBankCardCommandHandler(IUserRepository userRepository, IBankCardRepository bankCardRepository)
    {
        _userRepository = userRepository;
        _bankCardRepository = bankCardRepository;
    }

    public async Task<Unit> Handle(AddUserBankCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId)
            ?? throw new Exception($"UserId {request.UserId} is not found");

        await _bankCardRepository.Create(
            new BankCard
            {
                Balance = request.Balance,
                UserId = user.UserId,
                CardNumber = request.CardNumber
            });

        return Unit.Value;
    }
}
