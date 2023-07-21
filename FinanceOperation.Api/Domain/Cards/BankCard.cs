using Newtonsoft.Json;

namespace FinanceOperation.Domain.Cards;

public class BankCard
{
    [JsonProperty(PropertyName = "id")]
    public string Id => UserId;
    public string UserId { get; set; }
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
