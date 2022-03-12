using AutoMapper;
using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Cards;

namespace FinanceOperation.Core.Features.DiscountCards
{
    public class DiscountCardDto: IMapFrom<DiscountCard>, IMapTo<DiscountCard>
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }

        public void MapTo(Profile profile) => profile
            .CreateMap<DiscountCardDto, DiscountCard>();

        public void MapFrom(Profile profile) => profile
          .CreateMap<DiscountCard, DiscountCardDto>();
    }
}
