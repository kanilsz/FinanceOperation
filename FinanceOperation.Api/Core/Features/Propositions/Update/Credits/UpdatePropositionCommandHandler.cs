using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Update.Credits;

public class UpdateCreditPropositionCommand : IRequest, IMapTo<CreditProposition>
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
}

public class UpdatePropositionCommandHandler : IRequestHandler<UpdateCreditPropositionCommand>
{
    private readonly ICreditPropositionRepository _creditPropositionRepository;
    private readonly IMapper _mapper;

    public UpdatePropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository, IMapper mapper)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCreditPropositionCommand request, CancellationToken cancellationToken)
    {
        CreditProposition creditProposition = _mapper.Map<CreditProposition>(request);
        await _creditPropositionRepository.Update(creditProposition);
        return;
    }
}
