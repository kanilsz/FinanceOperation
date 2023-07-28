using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Remove;

public record RemovePropositionCommand : IRequest
{
    public int Id { get; set; }
    public string Type { get; set; }
}


public class RemovePropositionCommandHandler : IRequestHandler<RemovePropositionCommand>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly ICreditPropositionRepository _creditPropositionRepository;

    public RemovePropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository, IDepositPropositionRepository depositPropositionRepository)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _depositPropositionRepository = depositPropositionRepository;
    }

    public async Task Handle(RemovePropositionCommand request, CancellationToken cancellationToken)
    {

        var type = Enum.Parse(typeof(PropositionType), request.Type);
        if (type is PropositionType.Credit)
        {
            await _creditPropositionRepository.Delete(request.Id);
            return;
        }
        if (type is PropositionType.Deposit)
        {
            await _depositPropositionRepository.Delete(request.Id);
            return;
        }
    }
}
