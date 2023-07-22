using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using MediatR;

namespace FinanceOperation.Api.Core.Features.DiscountCards.GetList;

public class GetDiscountCardListQueryHandler : IRequestHandler<GetDiscountCardListQuery, IEnumerable<DiscountCardDto>>
{
    private readonly IDiscountCardRepository _discountCardRepository;
    private readonly IMapper _mapper;

    public GetDiscountCardListQueryHandler(IDiscountCardRepository discountCardRepository, IMapper mapper)
    {
        _discountCardRepository = discountCardRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DiscountCardDto>> Handle(GetDiscountCardListQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<DiscountCard> discountCards = await _discountCardRepository.GetDiscountCardsList(cancellationToken);
        return _mapper.Map<IEnumerable<DiscountCardDto>>(discountCards);
    }
}
