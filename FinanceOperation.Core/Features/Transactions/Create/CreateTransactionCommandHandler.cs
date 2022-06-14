using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Core.Features.Transactions.Create
{
    internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
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
            var transaction = _mapper.Map<Transaction>(request);
            await _repository.Create(transaction, cancellationToken);
            return Unit.Value;
        }
    }
}
