using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.GetList
{
    public class GetDiscountCardListFeatureHandler : IRequestHandler<GetDiscountCardListFeature, IEnumerable<DiscountCardDto>>
    {
        private readonly IDiscountCardRepository _discountCardRepository;
        private readonly IMapper _mapper;

        public GetDiscountCardListFeatureHandler(IDiscountCardRepository discountCardRepository, IMapper mapper)
        {
            _discountCardRepository = discountCardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiscountCardDto>> Handle(GetDiscountCardListFeature request, CancellationToken cancellationToken)
        {
            IEnumerable<DiscountCard> discountCards = await _discountCardRepository.GetDiscountCardsList(cancellationToken);
            return _mapper.Map<IEnumerable<DiscountCardDto>>(discountCards);
        }
    }
}
