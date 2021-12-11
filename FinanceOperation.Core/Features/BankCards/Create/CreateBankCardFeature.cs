using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Create
{
    public class CreateBankCardFeature : IRequest//, IMapTo<BankCard> //TODO: Should be dto 
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}
