using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Api.Infrastructure.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteBankCards;

public class DeleteUserBankCardCommandHandler : IRequestHandler<DeleteUserBankCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IBankCardRepository _bankCardRepository;

    public DeleteUserBankCardCommandHandler(IUserRepository userRepository, IBankCardRepository bankCardRepository)
    {
        _userRepository = userRepository;
        _bankCardRepository = bankCardRepository;
    }

    public async Task<Unit> Handle(DeleteUserBankCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId)
            ?? throw new Exception($"UserId {request.UserId} is not found");

        await _bankCardRepository.Remove(request.CardNumber, user.UserId);

        return Unit.Value;
    }
}
