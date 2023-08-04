using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Transactions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Transactions.Create;

public sealed record CreateTransactionCommand : IRequest<TransactionDto>, IMapTo<Transaction>
{
    public string BankName { get; set; }
    public string UserId { get; set; }
    public string Summary { get; set; }
}

internal sealed class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionDto>
{
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(ITransactionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        Transaction transaction = _mapper.Map<Transaction>(request);
        await _repository.Create(transaction, cancellationToken);
        return _mapper.Map<TransactionDto>(transaction);
    }
}
