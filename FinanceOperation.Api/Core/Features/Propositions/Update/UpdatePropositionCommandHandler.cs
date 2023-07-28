using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Update;

public class UpdatePropositionCommand : IRequest, IMapTo<CreditProposition>//, IMapTo<DepositProposition>
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
    private readonly IMapper _mapper;

    public UpdatePropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository, IDepositPropositionRepository depositPropositionRepository, IMapper mapper)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _depositPropositionRepository = depositPropositionRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdatePropositionCommand request, CancellationToken cancellationToken)
    {
        if (request.Type is "Credit")
        {
            CreditProposition creditProposition = _mapper.Map<CreditProposition>(request);
            await _creditPropositionRepository.Update(creditProposition);
            return;
        }
        if (request.Type is "Deposit")
        {
            DepositProposition creditProposition = _mapper.Map<DepositProposition>(request);
            await _depositPropositionRepository.Update(creditProposition);
            return;
        }

        return;
    }
}
