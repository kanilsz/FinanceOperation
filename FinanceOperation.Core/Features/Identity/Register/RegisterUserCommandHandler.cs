using AutoMapper;
using AutoMapper.Extensions.MappingProfile;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Users;
using MediatR;

namespace FinanceOperation.Core.Features.Identity.Register
{
    public record RegisterUserCommand() : IRequest, IMapTo<UserInfo>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void MapTo(Profile profile) => profile
            .CreateMap<RegisterUserCommand, UserInfo>();
    }

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            UserInfo user = _mapper.Map<UserInfo>(request);

            await _userRepository.Create(user, cancellationToken);
            return Unit.Value;
        }
    }
}
