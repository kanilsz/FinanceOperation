using MediatR;

namespace FinanceOperation.Api.Core.Features.BankCards.Delete;

public class DeleteBankCardCommand : IRequest
{
    public string CardNumber { get; set; }
}
