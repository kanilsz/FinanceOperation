using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Update.Deposit;

public class UpdateDepositPropositionCommand : IRequest, IMapTo<DepositProposition>
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
}

public class UpdateDepositPropositionCommandHandler : IRequestHandler<UpdateDepositPropositionCommand>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly IMapper _mapper;

    public UpdateDepositPropositionCommandHandler(IDepositPropositionRepository depositPropositionRepository, IMapper mapper)
    {
        _depositPropositionRepository = depositPropositionRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateDepositPropositionCommand request, CancellationToken cancellationToken)
    {

        DepositProposition depositProposition = _mapper.Map<DepositProposition>(request);
        await _depositPropositionRepository.Update(depositProposition);
        return;
    }
}
