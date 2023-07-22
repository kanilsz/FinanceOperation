using MediatR;

namespace FinanceOperation.Api.Core.Features.BankCards.GetList;

public class GetBankCardListQuery : IRequest<IEnumerable<BankCardDto>>
{
}
