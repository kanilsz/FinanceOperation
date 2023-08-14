using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Get;

public sealed record GetUserInfoQuery : IRequest<UserIdentityDto>
{
    public int Id { get; set; }
}


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
        UserIdentity userInfo = await _userRepository.GetUserBy(user => user.Id == request.Id);
        return _mapper.Map<UserIdentityDto>(userInfo);
    }
}

