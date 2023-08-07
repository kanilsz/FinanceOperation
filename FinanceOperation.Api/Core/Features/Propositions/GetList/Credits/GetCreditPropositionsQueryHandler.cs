using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.GetList.Credits;

public sealed record GetCreditPropositionsQuery(int? UserId) : IRequest<IList<CreditPropositionDto>>;

public sealed class GetCreditPropositionsQueryHandler : IRequestHandler<GetCreditPropositionsQuery, IList<CreditPropositionDto>>
{
    private readonly ICreditPropositionRepository _creditPropositionRepository;
    private readonly IMapper _mapper;

    public GetCreditPropositionsQueryHandler(ICreditPropositionRepository creditPropositionRepository, IMapper mapper)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _mapper = mapper;
    }

    public Task<IList<CreditPropositionDto>> Handle(GetCreditPropositionsQuery request, CancellationToken cancellationToken)
    {
        var deposits = _creditPropositionRepository.GetCreditList(request.UserId, cancellationToken);
        return Task.FromResult(_mapper.Map<IList<CreditPropositionDto>>(deposits));
    }
}
