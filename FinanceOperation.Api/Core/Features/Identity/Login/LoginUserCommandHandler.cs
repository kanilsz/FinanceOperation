using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Identity.Login;

public record LoginUserCommand : IRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand>
{
    private readonly IUserRepository _userRepository;

    public LoginUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserBy(user => user.Email == request.Email)
            ?? throw new Exception($"User with email {request.Email} it not found");

        if (user.Password != request.Password) 
        {
            throw new Exception($"Password is incorrect for user with email {request.Email}");
        }

        return;
    }
}
