using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Api.Infrastructure.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.UserData.GetUserData;

public record GetUserDataQuery(int UserId) : IRequest<UserDataDto>;

public class GetUserDataQueryHandler : IRequestHandler<GetUserDataQuery, UserDataDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IBankCardRepository _bankCardRepository;
    private readonly IDiscountCardRepository _discountCardRepository;
    private readonly IMapper _mapper;

    public GetUserDataQueryHandler(IUserRepository userRepository, IBankCardRepository bankCardRepository, IMapper mapper, IDiscountCardRepository discountCardRepository)
    {
        _userRepository = userRepository;
        _bankCardRepository = bankCardRepository;
        _mapper = mapper;
        _discountCardRepository = discountCardRepository;
    }

    public async Task<UserDataDto> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId);
        UserDataDto userDataDto = _mapper.Map<UserDataDto>(user);

        var userBankCards = await _bankCardRepository.GetUserBankCards(user.Id, cancellationToken);
        var userDiscountCards = await _discountCardRepository.GetUserDiscountCards(user.Id, cancellationToken);

        userDataDto.BankCards = _mapper.Map<IList<BankCardDto>>(userBankCards);
        userDataDto.Discounts = _mapper.Map<IList<DiscountCardDto>>(userDiscountCards);

        return userDataDto;
    }
}
