using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.Users.DeleteCards
{
    public class DeleteUserBankCardCommandHandler : IRequestHandler<DeleteUserBankCardCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserBankCardCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserBankCardCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserInfo(request.UserId, cancellationToken);

            var bankCardToRemove = user.BankCards.First(c => c.CardNumber == request.CardNumber);
            user.BankCards.Remove(bankCardToRemove);

            await _userRepository.Update(user, cancellationToken);

            return Unit.Value;
        }
    }
}
