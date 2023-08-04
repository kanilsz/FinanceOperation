using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Transactions.Delete;

public sealed record DeleteUserTransactionsCommand : IRequest
{
    public string UserId { get; set; }
}

internal class DeleteUserTransactionsCommandHandler : IRequestHandler<DeleteUserTransactionsCommand>
{
    private readonly ITransactionRepository _repository;

    public DeleteUserTransactionsCommandHandler(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteUserTransactionsCommand request, CancellationToken cancellationToken)
    {
        IList<Transaction> transactions = await _repository.GetUserTranscations(tr => request.UserId == tr.UserId, cancellationToken);

        await Task.WhenAll(transactions.Select(async t => await _repository.Delete(request.UserId, t.Id, cancellationToken)));

        return;
    }
}
