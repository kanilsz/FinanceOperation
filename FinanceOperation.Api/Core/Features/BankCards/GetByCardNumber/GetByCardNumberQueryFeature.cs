using MediatR;

namespace FinanceOperation.Api.Core.Features.BankCards.GetByCardNumber;

public class GetByCardNumberQueryFeature : IRequest<BankCardDto>
{
    public string CardNumber { get; set; }
}
