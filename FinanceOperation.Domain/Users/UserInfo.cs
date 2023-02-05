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
        public string Password { get; set; }
        public IList<BankCard> BankCards { get; set; }
        public IList<DiscountCard> DiscountCards { get; set; }
    }
}
