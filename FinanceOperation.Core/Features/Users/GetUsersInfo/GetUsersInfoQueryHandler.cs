using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUsersInfo;

internal class GetUsersInfoQueryHandler : IRequestHandler<GetUsersInfoQuery, IList<UserInfoDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersInfoQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<IList<UserInfoDto>> Handle(GetUsersInfoQuery request, CancellationToken cancellationToken)
    {
        IList<UserInfo> userInfos = await _userRepository.GetUsersInfoList(cancellationToken);
        return _mapper.Map<IList<UserInfoDto>>(userInfos);
    }
}
