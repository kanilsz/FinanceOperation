using FinanceOperation.API.Core.Repositories;
using FinanceOperation.API.Domain.Cards;
using MediatR;

namespace FinanceOperation.API.Core.Features.BankCards.Create
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
            BankCard bankCard = new BankCard()
            {
                CardNumber = request.CardNumber,
                Balance = request.Balance
            };
            await _bankCardRepository.Create(bankCard);

            return Unit.Value;
        }
    }
}
