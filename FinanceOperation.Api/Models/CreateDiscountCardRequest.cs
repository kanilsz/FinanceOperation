namespace FinanceOperation.Api.Models
{
    public class CreateDiscountCardRequest
    {
        public string? CardNumber { get; set; }
        public double Balance { get; set; }
    }
}