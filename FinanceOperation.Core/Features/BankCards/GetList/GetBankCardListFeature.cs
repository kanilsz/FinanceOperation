using MediatR;

namespace FinanceOperation.Core.Features.BankCards.GetList
{
    public class GetBankCardListFeature : IRequest<IEnumerable<BankCardDto>>
    {
    }
}
