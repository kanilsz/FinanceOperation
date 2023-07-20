using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;

namespace FinanceOperation.Api.Interactions.WebApi.Features.UserOperations;

public class CreateUserRequest
{
    public required string FirstName { get; set; }
    public required string SecondName { get; set; }
    public required string Email { get; set; }
    public required IEnumerable<BankCardDto> BankCards { get; set; }
    public required IEnumerable<DiscountCardDto> DiscountCards { get; set; }
}
