using AutoMapper;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.DiscountCards;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserCards
{
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
            UserIdentity userInfos = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

            return new CardsDto
            {
                DiscountCards = _mapper.Map<IList<DiscountCardDto>>(userInfos.DiscountCards),
                BankCards = _mapper.Map<IList<BankCardDto>>(userInfos.BankCards)
            };
        }
    }
}
