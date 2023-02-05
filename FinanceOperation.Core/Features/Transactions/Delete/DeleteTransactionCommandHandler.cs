using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.Transactions.Delete
{
    internal class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _repository;

        public DeleteTransactionCommandHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetUserTranscations(tr => request.UserId == tr.UserId, cancellationToken);

            foreach (var transaction in transactions)
            {
                await _repository.Delete(request.UserId, transaction.Id, cancellationToken);
            }
            return Unit.Value;
        }
    }
}
