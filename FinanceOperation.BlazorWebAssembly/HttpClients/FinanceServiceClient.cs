using Flurl;
using MSA.BuildingBlocks.ServiceClient;

namespace FinanceOperation.BlazorWebAssembly.HttpClients;

public class FinanceServiceClient : ServiceClientBase
{
    private const string CreditsPropositionSegment = "propositions/credits";
    private const string DepositsPropositionSegment = "propositions/deposits";
    private const string ApiVersion = "v1";

    public FinanceServiceClient(HttpClient httpClient, ILogger<ServiceClientBase> logger)
        : base(httpClient, ApiVersion, logger)
    {
    }

    public async Task<IEnumerable<CreditProposition>> GetCredits()
    {
        HttpRequestMessage requestMessage = ServiceUri.AbsoluteUri
            .AppendPathSegment(CreditsPropositionSegment)
            .WithHttpMethod(HttpMethod.Get);

        ServiceResponse<IEnumerable<CreditProposition>> response = await SendAsync<IEnumerable<CreditProposition>>(requestMessage);
        return response.Payload;
    }

    public async Task<IEnumerable<DepositProposition>> GetDeposits()
    {
        HttpRequestMessage requestMessage = ServiceUri.AbsoluteUri
            .AppendPathSegment(DepositsPropositionSegment)
            .WithHttpMethod(HttpMethod.Get);

        ServiceResponse<IEnumerable<DepositProposition>> response = await SendAsync<IEnumerable<DepositProposition>>(requestMessage);
        return response.Payload;
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
