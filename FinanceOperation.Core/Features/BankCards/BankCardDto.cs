using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Domain.Cards;

namespace FinanceOperation.Core.Features.BankCards;

public class BankCardDto : IMapFrom<BankCard>, IMapTo<BankCard>
{
    public string? CardNumber { get; set; }
    public double Balance { get; set; }

    public void MapTo(Profile profile)
    {
        _ = profile
       .CreateMap<BankCardDto, BankCard>();
    }

    public void MapFrom(Profile profile)
    {
        _ = profile
       .CreateMap<BankCard, BankCardDto>();
    }
}
