using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.Users.Delete;

internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Delete(request.Id, cancellationToken);
        return Unit.Value;
    }
}
