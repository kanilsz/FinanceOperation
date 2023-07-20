using MediatR;

namespace FinanceOperation.Core.Features.BankCards.GetList;

public class GetBankCardListQuery : IRequest<IEnumerable<BankCardDto>>
{
}
