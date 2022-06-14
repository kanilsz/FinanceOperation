using AutoMapper;
using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.Transactions.GetByUserId
{
    public class GetTransactionsByUserIdQueryHandler : IRequestHandler<GetTransactionsByUserIdQuery, UserIncomeOutcome>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionsByUserIdQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserIncomeOutcome> Handle(GetTransactionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetUserTranscations(tr => request.UserId == tr.UserId, cancellationToken);

            IList<Statistic> incomes = new List<Statistic>();
            IList<Statistic> outcomes = new List<Statistic>();

            foreach (var transaction in transactions)
            {
                var operation = transaction.Summary[0].ToString();
                var sum = double.Parse(transaction.Summary[1..]);

                if (operation == "+")
                {
                    if (incomes.Any(i => i.BankName == transaction.BankName))
                    {
                        incomes.First(i=>i.BankName==transaction.BankName).Summary += sum;
                    }
                    else
                    {
                        incomes.Add(new Statistic()
                        {
                            BankName = transaction.BankName,
                            Summary = sum
                        });
                    }

                    continue;
                }
                else if (transaction.Summary.StartsWith("-"))
                {
                    if (outcomes.Any(i => i.BankName == transaction.BankName))
                    {
                        outcomes.First(i => i.BankName == transaction.BankName).Summary += sum;
                    }
                    else
                    {
                        outcomes.Add(new Statistic()
                        {
                            BankName = transaction.BankName,
                            Summary = sum
                        });
                    }
                    
                    continue;
                }

            }

            return new UserIncomeOutcome
            {
                Incomes = incomes,
                Outcomes = outcomes
            };
        }
    }
}
