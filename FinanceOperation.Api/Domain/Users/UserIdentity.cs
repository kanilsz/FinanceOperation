using System.ComponentModel.DataAnnotations;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Propositions;

namespace FinanceOperation.Api.Domain.Users;

public class UserIdentity
{
    public UserIdentity()
    {
        Credits = new List<CreditProposition>();
        Deposits = new List<DepositProposition>();
    }

    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsDeleted { get; set; }
    public IList<CreditProposition> Credits { get; set; }
    public IList<DepositProposition> Deposits { get; set; }
}
