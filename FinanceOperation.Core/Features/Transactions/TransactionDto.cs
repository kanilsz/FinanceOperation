using FinanceOperation.Core.Mapping;
using FinanceOperation.Domain.Transactions;

namespace FinanceOperation.Core.Features.Transactions
{
    internal class TransactionDto: IMapTo<Transaction>, IMapFrom<Transaction>
    {
        public string Id { get; set; }
        public string BankName { get; set; }
        public string UserId { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
