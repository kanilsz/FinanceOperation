using FinanceOperation.API.Domain.Cards;
using MediatR;

namespace FinanceOperation.API.Core.Features.BankCards.GetByCardNumber
{
    public class GetBankCardQueryFeature : IRequest<BankCard>//TODO: Should be dto 
    {
        public string CardNumber { get; set; }
    }
}
