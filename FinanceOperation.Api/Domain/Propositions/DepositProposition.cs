using System.ComponentModel.DataAnnotations;

namespace FinanceOperation.Api.Domain.Propositions;

public class DepositProposition
{
    [Key]
    public int DepositId { get; set; }
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public double Summary { get; set; }
    public double Percentage { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
