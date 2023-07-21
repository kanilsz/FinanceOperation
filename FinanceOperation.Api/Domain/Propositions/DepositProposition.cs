using System.ComponentModel.DataAnnotations;

namespace FinanceOperation.Api.Domain.Propositions;

public class DepositProposition
{
    [Key]
    public int DepositPropositionId { get; set; }
    public int UserIdentityId { get; set; }
    public string PropositionNumber { get; set; }
    public double Summary { get; set; }
    public double Percentage { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
