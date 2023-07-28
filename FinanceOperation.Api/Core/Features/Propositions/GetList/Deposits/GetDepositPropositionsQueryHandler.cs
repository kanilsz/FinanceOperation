using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.GetList.Deposits;

public sealed record GetDepositPropositionsQuery : IRequest<IList<DepositPropositionDto>>;

public sealed class GetDepositPropositionsQueryHandler : IRequestHandler<GetDepositPropositionsQuery, IList<DepositPropositionDto>>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly IMapper _mapper;

    public GetDepositPropositionsQueryHandler(IDepositPropositionRepository depositPropositionRepository, IMapper mapper)
    {
        _depositPropositionRepository = depositPropositionRepository;
        _mapper = mapper;
    }

    public Task<IList<DepositPropositionDto>> Handle(GetDepositPropositionsQuery request, CancellationToken cancellationToken)
    {   
        var deposits = _depositPropositionRepository.GetDepositList(cancellationToken);
        return Task.FromResult(_mapper.Map<IList<DepositPropositionDto>>(deposits));
    }
}
