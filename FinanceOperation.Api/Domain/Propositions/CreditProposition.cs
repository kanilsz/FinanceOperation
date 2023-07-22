using System.ComponentModel.DataAnnotations;

namespace FinanceOperation.Domain.Propositions;
public class CreditProposition
{
    [Key]
    public int CreditId { get; set; }
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public double Summary { get; set; }
    public double Percentage { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
