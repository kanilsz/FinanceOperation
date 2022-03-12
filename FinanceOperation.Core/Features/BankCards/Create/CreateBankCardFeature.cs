using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Create
{
    public class CreateBankCardFeature : IRequest , IMapTo<BankCard> 
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}
