using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Users.GetUserInfo
{
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
            UserIdentity userInfos = await _userRepository.GetUserInfo(request.UserId, cancellationToken);
            return _mapper.Map<UserIdentityDto>(userInfos);
        }
    }
}

