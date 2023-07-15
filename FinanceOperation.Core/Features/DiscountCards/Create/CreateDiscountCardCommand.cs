using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.Create;

public class CreateDiscountCardCommand : IRequest, IMapTo<DiscountCard>
{
    public string? CardNumber { get; set; }
    public double Balance { get; set; }
}
