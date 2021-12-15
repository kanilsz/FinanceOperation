using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Delete
{
    public class DeleteBankCardFeature : IRequest
    {
        public string? CardNumber { get; set; }
    }
}
