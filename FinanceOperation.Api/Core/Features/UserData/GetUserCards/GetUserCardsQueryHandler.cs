using AutoMapper;
using FinanceOperation.Api.Core.Features.UserData;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.GetUserCards;

public class GetUserCardsQueryHandler : IRequestHandler<GetUserCardsQuery, CardsDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IBankCardRepository _bankCardRepository;
    private readonly IDiscountCardRepository _discountCardRepository;
    private readonly IMapper _mapper;

    public GetUserCardsQueryHandler(IUserRepository userRepository, IMapper mapper, IDiscountCardRepository discountCardRepository, IBankCardRepository bankCardRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _discountCardRepository = discountCardRepository;
        _bankCardRepository = bankCardRepository;
    }

    public async Task<CardsDto> Handle(GetUserCardsQuery request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId);

        var userDiscountCards = await _discountCardRepository.GetUserDiscountCards(user.Id, cancellationToken);
        var userBankCards = await _bankCardRepository.GetUserBankCards(user.Id, cancellationToken);
        return new CardsDto
        {
            DiscountCards = _mapper.Map<IList<DiscountCardDto>>(userDiscountCards),
            BankCards = _mapper.Map<IList<BankCardDto>>(userBankCards)
        };
    }
}
