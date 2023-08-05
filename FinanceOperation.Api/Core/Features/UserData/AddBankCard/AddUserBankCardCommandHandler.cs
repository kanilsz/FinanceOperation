using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.AddBankCard;

public record AddUserBankCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}

internal class AddUserBankCardCommandHandler : IRequestHandler<AddUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IBankCardRepository _bankCardRepository;

    public AddUserBankCardCommandHandler(IUserRepository userRepository, IBankCardRepository bankCardRepository)
    {
        _userRepository = userRepository;
        _bankCardRepository = bankCardRepository;
    }

    public async Task Handle(AddUserBankCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId);

        await _bankCardRepository.Create(
            new BankCard
            {
                Balance = request.Balance,
                UserId = user.Id,
                CardNumber = request.CardNumber
            });

        return;
    }
}
