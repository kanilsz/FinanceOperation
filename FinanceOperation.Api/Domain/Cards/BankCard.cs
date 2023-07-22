using Newtonsoft.Json;

namespace FinanceOperation.Api.Domain.Cards;

public class BankCard
{
    [JsonProperty(PropertyName = "id")]
    public string Id => CardNumber;
    public int UserId { get; set; }
    public string CardNumber { get; set; }
    public double Balance { get; set; }
}
