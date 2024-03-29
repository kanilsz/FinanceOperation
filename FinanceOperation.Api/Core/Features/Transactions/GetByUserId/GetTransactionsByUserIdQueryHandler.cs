﻿using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Transactions.GetByUserId;

public sealed record GetTransactionsByUserIdQuery : IRequest<UserIncomeOutcome>
{
    public string UserId { get; set; }
}

internal class GetTransactionsByUserIdQueryHandler : IRequestHandler<GetTransactionsByUserIdQuery, UserIncomeOutcome>
{
    private readonly ITransactionRepository _repository;

    public GetTransactionsByUserIdQueryHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserIncomeOutcome> Handle(GetTransactionsByUserIdQuery request, CancellationToken cancellationToken)
    {
        IList<Transaction> transactions = await _repository.GetUserTranscations(tr => request.UserId == tr.UserId, cancellationToken);

        IList<Statistic> incomes = new List<Statistic>();
        IList<Statistic> outcomes = new List<Statistic>();

        foreach (Transaction transaction in transactions)
        {
            string operation = transaction.Summary[0].ToString();
            double sum = double.Parse(transaction.Summary[1..]);

            if (operation == "+")
            {
                if (incomes.Any(i => i.BankName == transaction.BankName))
                {
                    incomes.First(i => i.BankName == transaction.BankName).Summary += sum;
                    continue;
                }

                incomes.Add(new Statistic()
                {
                    BankName = transaction.BankName,
                    Summary = sum
                });
                continue;
            }

            if (outcomes.Any(i => i.BankName == transaction.BankName))
            {
                outcomes.First(i => i.BankName == transaction.BankName).Summary += sum;
                continue;
            }
            outcomes.Add(new Statistic()
            {
                BankName = transaction.BankName,
                Summary = sum
            });


        }

        return new UserIncomeOutcome
        {
            Incomes = incomes,
            Outcomes = outcomes
        };
    }
}
