namespace FinanceOperation.Api.Features.UserOperations;

public class AddUserCardRequest
{
    public string? CardNumber { get; set; }
    public double Balance { get; set; }
}
