using FinanceOperation.Api.Core.Features.UserData;

namespace FinanceOperation.Api.Core.Features.Users.GetUserCards;

public class CardsDto
{
    public IEnumerable<BankCardDto> BankCards { get; set; }
    public IEnumerable<DiscountCardDto> DiscountCards { get; set; }
}
