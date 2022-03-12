using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceOperation.Core.Features.DiscountCards.GetByDiscountNumber
{
    public class GetByDiscountNumberQueryFeatureHandler : IRequestHandler<GetByDiscountNumberQueryFeature, DiscountCardDto>
    {
        private readonly IDiscountCardRepository _discountCardRepository;
        private readonly IMapper _mapper;
        public GetByDiscountNumberQueryFeatureHandler(IDiscountCardRepository discountCardRepository, IMapper mapper)
        {
            _discountCardRepository = discountCardRepository;
            _mapper = mapper;
        }

        public async Task<DiscountCardDto> Handle(GetByDiscountNumberQueryFeature request, CancellationToken cancellationToken)
        {
            DiscountCard? discountCard = await _discountCardRepository.GetByDiscountNumber(request.CardNumber, cancellationToken);
            return _mapper.Map<DiscountCardDto>(discountCard);
        }
    }
}
