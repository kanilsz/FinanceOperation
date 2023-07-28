using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Get.CreditDetails;

public record GetCreditPropositionDetailsQuery(int Id) : IRequest<CreditPropositionDto>;

public class GetCreditPropositionDetailsQueryHandler : IRequestHandler<GetCreditPropositionDetailsQuery, CreditPropositionDto>
{
    private readonly ICreditPropositionRepository _creditPropositionRepository;
    private readonly IMapper _mapper;


    public GetCreditPropositionDetailsQueryHandler(ICreditPropositionRepository creditPropositionRepository, IMapper mapper)
    {
        _creditPropositionRepository = creditPropositionRepository;
        _mapper = mapper;
    }

    public async Task<CreditPropositionDto> Handle(GetCreditPropositionDetailsQuery request, CancellationToken cancellationToken)
    {
        CreditProposition credit = await _creditPropositionRepository.GetCredit(request.Id, cancellationToken)
               ?? throw new Exception($"Unable to find the credit with id {request.Id}");

        return _mapper.Map<CreditPropositionDto>(credit);
    }
}
