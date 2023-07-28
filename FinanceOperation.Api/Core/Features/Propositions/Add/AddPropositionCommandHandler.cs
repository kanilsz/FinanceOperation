using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Add;

public class AddPropositionCommand : IRequest<Unit>
{
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
    public string Type { get; set; }
}

public class AddPropositionCommandHandler : IRequestHandler<AddPropositionCommand, Unit>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly ICreditPropositionRepository _creditPropositionRepository;

    public AddPropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository, IDepositPropositionRepository depositPropositionRepository)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _depositPropositionRepository = depositPropositionRepository;
    }

    public async Task<Unit> Handle(AddPropositionCommand request, CancellationToken cancellationToken)
    {
        var type = Enum.Parse(typeof(PropositionType), request.Type);
        if (type is PropositionType.Credit)
        {
            CreditProposition credit = new()
            {
                UserId = request.UserId,
                Summary = request.Summary,
                PropositionNumber = request.PropositionNumber,
                Percentage = request.Percentage
            };
            await _creditPropositionRepository.Create(credit);
            return Unit.Value;
        }
        if (type is PropositionType.Deposit)
        {
            DepositProposition deposit = new()
            {
                UserId = request.UserId,
                Summary = request.Summary,
                PropositionNumber = request.PropositionNumber,
                Percentage = request.Percentage
            };
            await _depositPropositionRepository.Create(deposit);
            return Unit.Value;
        }

        return Unit.Value;
    }
}
