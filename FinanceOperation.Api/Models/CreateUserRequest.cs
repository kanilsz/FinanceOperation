using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;

namespace FinanceOperation.Api.Models
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<BankCardDto> BankCards { get; set; }
        public IEnumerable<DiscountCardDto> DiscountCards { get; set; }
    }
}
