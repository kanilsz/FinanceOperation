using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Core.Features.Transactions.Delete
{
    public class DeleteTransactionCommand : IRequest, IMapTo<Transaction>
    {
        public string UserId{ get; set; }
    }
}
