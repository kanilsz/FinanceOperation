using AutoMapper;
using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = _mapper.Map<UserIdentity>(request);

        await _userRepository.Update(user);

        return Unit.Value;
    }
}
