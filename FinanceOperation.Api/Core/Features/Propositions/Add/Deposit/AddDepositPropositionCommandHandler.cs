using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Add.Deposit;

public class AddDepositPropositionCommand : IRequest<DepositPropositionDto>, IMapTo<DepositProposition>
{
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
}

public class AddDepositPropositionCommandHandler : IRequestHandler<AddDepositPropositionCommand, DepositPropositionDto>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly IMapper _mapper;

    public AddDepositPropositionCommandHandler(IDepositPropositionRepository depositPropositionRepository, IMapper mapper)
    {
        _depositPropositionRepository = depositPropositionRepository;
        _mapper = mapper;
    }

    public async Task<DepositPropositionDto> Handle(AddDepositPropositionCommand request, CancellationToken cancellationToken)
    {

        DepositProposition deposit = _mapper.Map<DepositProposition>(request);
        await _depositPropositionRepository.Create(deposit);
        return _mapper.Map<DepositPropositionDto>(deposit);
    }
}
