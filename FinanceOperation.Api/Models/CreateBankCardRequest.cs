namespace FinanceOperation.Api.Models
{
    public class CreateBankCardRequest
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}