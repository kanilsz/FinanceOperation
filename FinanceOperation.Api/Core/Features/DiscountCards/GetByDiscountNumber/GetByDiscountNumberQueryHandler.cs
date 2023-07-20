using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.GetByDiscountNumber;

public class GetByDiscountNumberQueryHandler : IRequestHandler<GetByDiscountNumberQuery, DiscountCardDto>
{
    private readonly IDiscountCardRepository _discountCardRepository;
    private readonly IMapper _mapper;
    public GetByDiscountNumberQueryHandler(IDiscountCardRepository discountCardRepository, IMapper mapper)
    {
        _discountCardRepository = discountCardRepository;
        _mapper = mapper;
    }

    public async Task<DiscountCardDto> Handle(GetByDiscountNumberQuery request, CancellationToken cancellationToken)
    {
        DiscountCard discountCard = await _discountCardRepository.GetByDiscountNumber(request.CardNumber, cancellationToken);
        return _mapper.Map<DiscountCardDto>(discountCard);
    }
}
