using System.ComponentModel.DataAnnotations;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Propositions;
using Newtonsoft.Json;

namespace FinanceOperation.Domain.Users;

public class UserIdentity
{
    public UserIdentity()
    {
        Credits = new List<CreditProposition>();
        Deposits = new List<DepositProposition>();
    }

    [Key]
    public int UserIdentityId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<CreditProposition> Credits { get; set; }
    public IList<DepositProposition> Deposits { get; set; }
}
