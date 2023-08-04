using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Update;

public sealed record UpdateUserCommand : IRequest<UserIdentityDto>, IMapTo<UserIdentity>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool? IsDeleted { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserIdentityDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserIdentityDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = _mapper.Map<UserIdentity>(request);
        await _userRepository.Update(user);

        return _mapper.Map<UserIdentityDto>(user);
    }
}
