using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Propositions;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Propositions.Get.DepositDetails;

public record GetDepositPropositionDetailsQuery(int Id) : IRequest<DepositPropositionDto>;

public class GetDepositPropositionDetailsQueryHandler : IRequestHandler<GetDepositPropositionDetailsQuery, DepositPropositionDto>
{
    private readonly IDepositPropositionRepository _depositPropositionRepository;
    private readonly IMapper _mapper;

    public GetDepositPropositionDetailsQueryHandler(IDepositPropositionRepository depositPropositionRepository, IMapper mapper)
    {
        _depositPropositionRepository = depositPropositionRepository;
        _mapper = mapper;
    }

    public async Task<DepositPropositionDto> Handle(GetDepositPropositionDetailsQuery request, CancellationToken cancellationToken)
    {
        DepositProposition deposit = await _depositPropositionRepository.GetDeposit(request.Id, cancellationToken)
               ?? throw new Exception($"Unable to find the deposit with id {request.Id}");

        return _mapper.Map<DepositPropositionDto>(deposit);
    }
}
