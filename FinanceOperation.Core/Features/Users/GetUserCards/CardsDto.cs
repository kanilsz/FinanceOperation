using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;

namespace FinanceOperation.Core.Features.Users.GetUserCards
{
    public class CardsDto
    {
        public IEnumerable<BankCardDto> BankCards { get; set; }
        public IEnumerable<DiscountCardDto> DiscountCards { get; set; }
    }
}
