using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserInfo
{
    public class GetUserInfoFeatureHandler : IRequestHandler<GetUserInfoFeature, UserInfoDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserInfoFeatureHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> Handle(GetUserInfoFeature request, CancellationToken cancellationToken)
        {
            UserInfo userInfos = await _userRepository.GetUserInfoList(request.UserId, cancellationToken);
            return _mapper.Map<UserInfoDto>(userInfos);
        }
    }
}

