using MediatR;

namespace FinanceOperation.Core.Features.BankCards.GetByCardNumber;

public class GetByCardNumberQueryFeature : IRequest<BankCardDto>
{
    public string CardNumber { get; set; }
}
