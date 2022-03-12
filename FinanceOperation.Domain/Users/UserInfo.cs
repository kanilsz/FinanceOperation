using FinanceOperation.Domain.Cards;
using Newtonsoft.Json;

namespace FinanceOperation.Domain.Users
{
    public class UserInfo
    {
        public UserInfo()
        {
            Id = Guid.NewGuid().ToString();
            BankCards = new List<BankCard>();
            DiscountCards = new List<DiscountCard>();
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public IEnumerable<BankCard> BankCards { get; set; }
        public IEnumerable<DiscountCard> DiscountCards { get; set; }
    }
}
