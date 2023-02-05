﻿using MediatR;

namespace FinanceOperation.Core.Features.Transactions.GetByUserId
{
    public class GetTransactionsByUserIdQuery: IRequest<UserIncomeOutcome>
    {
        public string UserId { get; set; }
    }
}
