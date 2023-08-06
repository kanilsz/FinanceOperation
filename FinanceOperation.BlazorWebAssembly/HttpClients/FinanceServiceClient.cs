using Flurl;
using MSA.BuildingBlocks.ServiceClient;

namespace FinanceOperation.BlazorWebAssembly.HttpClients;

public class FinanceServiceClient : ServiceClientBase
{
    private const string CreditsPropositionSegment = "/v1/propositions/credits";
    private const string DepositsPropositionSegment = "/v1/propositions/deposits";

    public FinanceServiceClient(HttpClient httpClient, ILogger<ServiceClientBase> logger) 
        : base(httpClient, logger)
    {
    }

    public async Task<IEnumerable<CreditProposition>> GetCredits()
    {
        HttpRequestMessage requestMessage = ServiceUri.AbsoluteUri
            .AppendPathSegment(CreditsPropositionSegment)
            .WithHttpMethod(HttpMethod.Get);

        return (await Send<IEnumerable<CreditProposition>>(requestMessage)).Payload;
    }

    public async Task<IEnumerable<DepositProposition>> GetDeposits()
    {
        HttpRequestMessage requestMessage = ServiceUri.AbsoluteUri
            .AppendPathSegment(DepositsPropositionSegment)
            .WithHttpMethod(HttpMethod.Get);

        return (await Send<IEnumerable<DepositProposition>>(requestMessage)).Payload;
    }
}

public record CreditProposition
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string PropositionNumber { get; set; }

    public double Summary { get; set; }

    public double Percentage { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
}

public record DepositProposition
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string PropositionNumber { get; set; }

    public double Summary { get; set; }

    public double Percentage { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }
}
