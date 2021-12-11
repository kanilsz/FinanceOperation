using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.BankCards.GetByCardNumber
{
    public class GetByCardNumberQueryFeatureHandler : IRequestHandler<GetByCardNumberQueryFeature, BankCardDto>
    {
        private readonly IBankCardRepository _bankCardRepository;
        private readonly IMapper _mapper;

        public GetByCardNumberQueryFeatureHandler(IBankCardRepository bankCardRepository, IMapper mapper)
        {
            _bankCardRepository = bankCardRepository;
            _mapper = mapper;
        }

        public async Task<BankCardDto> Handle(GetByCardNumberQueryFeature request, CancellationToken cancellationToken)
        {
            BankCard? bankCard = await _bankCardRepository.GetByCardNumber(request.CardNumber, cancellationToken);
            return _mapper.Map<BankCardDto>(bankCard);
        }
    }
}
