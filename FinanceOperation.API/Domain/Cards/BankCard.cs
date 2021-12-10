using Newtonsoft.Json;

namespace FinanceOperation.API.Domain.Cards
{
    public class BankCard
    {
        [JsonProperty(PropertyName = "id")]
        public string Id => CardNumber;
        public string CardNumber { get; set; }
        public double Balance { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
