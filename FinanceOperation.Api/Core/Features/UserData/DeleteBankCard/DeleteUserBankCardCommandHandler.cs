using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteBankCards;

public record DeleteUserBankCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
}

public class DeleteUserBankCardCommandHandler : IRequestHandler<DeleteUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IBankCardRepository _bankCardRepository;

    public DeleteUserBankCardCommandHandler(IUserRepository userRepository, IBankCardRepository bankCardRepository)
    {
        _userRepository = userRepository;
        _bankCardRepository = bankCardRepository;
    }

    public async Task Handle(DeleteUserBankCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUserBy(user => user.Id == request.UserId);

        await _bankCardRepository.Remove(request.CardNumber, user.Id);

        return;
    }
}
