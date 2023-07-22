using Newtonsoft.Json;

namespace FinanceOperation.Api.Domain.Cards;

public class DiscountCard
{
    [JsonProperty(PropertyName = "id")]
    public string Id => UserId;
    public string UserId { get; set; }
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
