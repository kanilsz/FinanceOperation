namespace FinanceOperation.Core.Features.Transactions.GetByUserId;

public class UserIncomeOutcome
{
    public UserIncomeOutcome()
    {
        Incomes = new List<Statistic>();
        Outcomes = new List<Statistic>();
    }

    public IList<Statistic> Incomes { get; set; }
    public IList<Statistic> Outcomes { get; set; }
}


public class Statistic
{
    public string BankName { get; set; }
    public double Summary { get; set; }
}
