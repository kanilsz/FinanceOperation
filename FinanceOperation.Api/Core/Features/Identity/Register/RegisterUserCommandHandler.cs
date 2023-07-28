using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Register;

public record RegisterUserCommand : IRequest<int>, IMapTo<UserIdentity>
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = _mapper.Map<UserIdentity>(request);

        return await _userRepository.Create(user);
    }
}
