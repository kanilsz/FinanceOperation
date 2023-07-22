using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Domain.Cards;
using MediatR;

namespace FinanceOperation.Api.Core.Features.BankCards.Create;

public class CreateBankCardCommand : IRequest, IMapTo<BankCard>
{
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
