using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Cards;

namespace FinanceOperation.Core.Features.BankCards
{
    public class BankCardDto : IMapFrom<BankCard>, IMapTo<BankCard>
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}
