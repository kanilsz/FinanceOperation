namespace FinanceOperation.Api.Features.Transactions
{
    public class CreateUserTransactionRequest
    {
        public string BankName { get; set; }
        public string UserId { get; set; }
        public string Summary { get; set; }
    }
}
