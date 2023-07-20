namespace FinanceOperation.Infrastructure.Configs;

public record CosmosConfigs
{
    public string ConnectionString { get; init; }
    public string DatabaseName { get; init; }
    public int Throughput { get; set; }
}
