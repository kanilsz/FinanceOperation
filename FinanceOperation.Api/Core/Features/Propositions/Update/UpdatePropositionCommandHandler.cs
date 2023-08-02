using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Update;

public class UpdatePropositionCommand : IRequest
{
    public int PropositionId { get; set; }
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
    public string Type { get; set; }
}

public class UpdatePropositionCommandHandler : IRequestHandler<UpdatePropositionCommand>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly ICreditPropositionRepository _creditPropositionRepository;

    public UpdatePropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository, IDepositPropositionRepository depositPropositionRepository)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _depositPropositionRepository = depositPropositionRepository;
    }

    public async Task Handle(UpdatePropositionCommand request, CancellationToken cancellationToken)
    {
        if (request.Type is "Credit")
        {
            CreditProposition creditProposition = new()
            {
                Id = request.PropositionId,
                UserId = request.UserId,
                Percentage = request.Percentage,
                Summary = request.Summary,
                PropositionNumber = request.PropositionNumber
            };
            await _creditPropositionRepository.Update(creditProposition);
            return;
        }
        if (request.Type is "Deposit")
        {
            DepositProposition creditProposition = new()
            {
                Id = request.PropositionId,
                UserId = request.UserId,
                Percentage = request.Percentage,
                Summary = request.Summary,
                PropositionNumber = request.PropositionNumber
            };
            await _depositPropositionRepository.Update(creditProposition);
            return;
        }

        return;
    }
}
