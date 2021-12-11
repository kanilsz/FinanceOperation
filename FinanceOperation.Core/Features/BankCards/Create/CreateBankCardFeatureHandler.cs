using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Create
{
    public class CreateBankCardFeatureHandler : IRequestHandler<CreateBankCardFeature, Unit>
    {
        private readonly IBankCardRepository _bankCardRepository;

        public CreateBankCardFeatureHandler(IBankCardRepository bankCardRepository)
        {
            _bankCardRepository = bankCardRepository;
        }

        public async Task<Unit> Handle(CreateBankCardFeature request, CancellationToken cancellationToken)
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
}
