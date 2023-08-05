using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Remove.Deposit;

public record RemoveDepositPropositionCommand : IRequest
{
    public int Id { get; set; }
}

public class RemoveDepositPropositionCommandHandler : IRequestHandler<RemoveDepositPropositionCommand>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;

    public RemoveDepositPropositionCommandHandler(IDepositPropositionRepository depositPropositionRepository)
    {
        _depositPropositionRepository = depositPropositionRepository;
    }

    public async Task Handle(RemoveDepositPropositionCommand request, CancellationToken cancellationToken)
    {
        await _depositPropositionRepository.Delete(request.Id);
        return;
    }
}
