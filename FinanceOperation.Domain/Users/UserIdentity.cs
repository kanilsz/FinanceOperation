using FinanceOperation.Domain.Cards;
using FinanceOperation.Domain.Propositions;
using Newtonsoft.Json;

namespace FinanceOperation.Domain.Users;

public class UserIdentity
{
    public UserIdentity()
    {
        BankCards = new List<BankCard>();
        DiscountCards = new List<DiscountCard>();
    }

    public int UserIdentityId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IList<BankCard> BankCards { get; set; }
    public IList<DiscountCard> DiscountCards { get; set; }
    public IList<Proposition> Credits { get; set; }
    public IList<Proposition> Deposits { get; set; }
}
