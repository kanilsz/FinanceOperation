using FinanceOperation.API.Core.Repositories;
using FinanceOperation.API.Domain.Cards;
using MediatR;

namespace FinanceOperation.API.Core.Features.BankCards.GetByCardNumber
{
    public class GetByCardNumberQueryFeatureHandler : IRequestHandler<GetBankCardQueryFeature, BankCard> //TODO:Should be dto
    {
        private readonly IBankCardRepository _bankCardRepository;

        public GetByCardNumberQueryFeatureHandler(IBankCardRepository bankCardRepository)
        {
            _bankCardRepository = bankCardRepository;
        }

        public async Task<BankCard> Handle(GetBankCardQueryFeature request, CancellationToken cancellationToken)
        {

            return await _bankCardRepository.GetByCardNumber(request.CardNumber, cancellationToken);
        }
    }
}
