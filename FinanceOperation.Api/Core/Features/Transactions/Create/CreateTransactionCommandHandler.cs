using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Transactions.Create;

internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Unit>
{
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(ITransactionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        Transaction transaction = _mapper.Map<Transaction>(request);
        await _repository.Create(transaction, cancellationToken);
        return Unit.Value;
    }
}
