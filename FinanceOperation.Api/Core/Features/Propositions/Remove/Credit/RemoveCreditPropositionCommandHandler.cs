using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Remove.Credit;

public record RemoveCreditPropositionCommand : IRequest
{
    public int Id { get; set; }
}

public class RemoveCreditPropositionCommandHandler : IRequestHandler<RemoveCreditPropositionCommand>
{
    private readonly ICreditPropositionRepository _creditPropositionRepository;

    public RemoveCreditPropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository)
    {
        _creditPropositionRepository = creditPropositionRepository;
    }

    public async Task Handle(RemoveCreditPropositionCommand request, CancellationToken cancellationToken)
    {
        await _creditPropositionRepository.Delete(request.Id);
        return;
    }
}
