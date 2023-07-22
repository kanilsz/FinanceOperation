using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using MediatR;

namespace FinanceOperation.Api.Core.Features.BankCards.GetList;

public class GetBankCardListQueryHandler : IRequestHandler<GetBankCardListQuery, IEnumerable<BankCardDto>>
{
    private readonly IBankCardRepository _bankCardRepository;
    private readonly IMapper _mapper;

    public GetBankCardListQueryHandler(IBankCardRepository bankCardRepository, IMapper mapper)
    {
        _bankCardRepository = bankCardRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BankCardDto>> Handle(GetBankCardListQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<BankCard> bankCards = await _bankCardRepository.GetBankCardsList(cancellationToken);
        return _mapper.Map<IEnumerable<BankCardDto>>(bankCards);
    }
}
