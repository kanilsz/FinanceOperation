using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Get;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, UserIdentityDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserInfoQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserIdentityDto> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        UserIdentity userInfos = await _userRepository.GetUser(request.UserId);
        return _mapper.Map<UserIdentityDto>(userInfos);
    }
}

