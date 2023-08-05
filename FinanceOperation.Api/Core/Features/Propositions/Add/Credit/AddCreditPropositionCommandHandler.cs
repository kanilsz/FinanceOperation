using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Add.Credit;

public class AddCreditPropositionCommand : IRequest<CreditPropositionDto>, IMapTo<CreditProposition>
{
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
}

public class AddCreditPropositionCommandHandler : IRequestHandler<AddCreditPropositionCommand, CreditPropositionDto>
{
    private readonly ICreditPropositionRepository _creditPropositionRepository;
    private readonly IMapper _mapper;

    public AddCreditPropositionCommandHandler(ICreditPropositionRepository creditPropositionRepository, IMapper mapper)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _mapper = mapper;
    }

    public async Task<CreditPropositionDto> Handle(AddCreditPropositionCommand request, CancellationToken cancellationToken)
    {
        CreditProposition credit = _mapper.Map<CreditProposition>(request);
        await _creditPropositionRepository.Create(credit);
        return _mapper.Map<CreditPropositionDto>(credit);
    }
}
