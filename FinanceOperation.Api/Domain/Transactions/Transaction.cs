using Newtonsoft.Json;

namespace FinanceOperation.Domain.Transactions;

public class Transaction
{
    public Transaction()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAtUtc = DateTime.UtcNow;
    }

    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }
    public string BankName { get; set; }
    public string UserId { get; set; }
    public string Summary { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
