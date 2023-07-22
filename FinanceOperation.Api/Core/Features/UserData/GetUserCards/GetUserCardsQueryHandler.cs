using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.GetUserCards;

public class GetUserCardsQueryHandler : IRequestHandler<GetUserCardsQuery, CardsDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserCardsQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CardsDto> Handle(GetUserCardsQuery request, CancellationToken cancellationToken)
    {
        _ = await _userRepository.GetUser(request.UserId, cancellationToken);

        // TODO Fix logic
        return new CardsDto
        {
            //DiscountCards = _mapper.Map<IList<DiscountCardDto>>(userInfos.DiscountCards),
            //BankCards = _mapper.Map<IList<BankCardDto>>(userInfos.BankCards)
        };
    }
}
