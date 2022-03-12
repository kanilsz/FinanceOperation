using Newtonsoft.Json;

namespace FinanceOperation.Domain.Cards
{
    public class DiscountCard
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id => CardNumber;
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}
