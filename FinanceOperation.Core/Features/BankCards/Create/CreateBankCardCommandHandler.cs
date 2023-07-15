using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Create;

public class CreateBankCardCommandHandler : IRequestHandler<CreateBankCardCommand, Unit>
{
    private readonly IBankCardRepository _bankCardRepository;

    public CreateBankCardCommandHandler(IBankCardRepository bankCardRepository)
    {
        _bankCardRepository = bankCardRepository;
    }

    public async Task<Unit> Handle(CreateBankCardCommand request, CancellationToken cancellationToken)
    {
        BankCard bankCard = new()
        {
            CardNumber = request.CardNumber,
            Balance = request.Balance
        };
        await _bankCardRepository.Create(bankCard, cancellationToken);

        return Unit.Value;
    }
}
