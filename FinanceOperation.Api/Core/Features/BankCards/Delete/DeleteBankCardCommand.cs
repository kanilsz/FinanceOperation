using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Delete;

public class DeleteBankCardCommand : IRequest
{
    public string CardNumber { get; set; }
}
