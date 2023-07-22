using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Cards;
using MediatR;

namespace FinanceOperation.Api.Core.Features.DiscountCards.Create;

public class CreateDiscountCardCommand : IRequest, IMapTo<DiscountCard>
{
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
