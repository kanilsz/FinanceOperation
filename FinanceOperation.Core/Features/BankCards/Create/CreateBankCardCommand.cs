using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Create;

public class CreateBankCardCommand : IRequest, IMapTo<BankCard>
{
    public string? CardNumber { get; set; }
    public double Balance { get; set; }
}
