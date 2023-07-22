using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Cards;

namespace FinanceOperation.Api.Core.Features.UserData;

public class DiscountCardDto : IMapFrom<DiscountCard>, IMapTo<DiscountCard>
{
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
