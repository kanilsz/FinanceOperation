using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Api.Infrastructure.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteDiscountCards;

public class DeleteUserDiscountCardCommandHandler : IRequestHandler<DeleteUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IDiscountCardRepository _discountCardRepository;

    public DeleteUserDiscountCardCommandHandler(IUserRepository userRepository, IDiscountCardRepository discountCardRepository)
    {
        _userRepository = userRepository;
        _discountCardRepository = discountCardRepository;
    }

    public async Task<Unit> Handle(DeleteUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId)
            ?? throw new Exception($"UserId {request.UserId} is not found");

        await _discountCardRepository.Remove(request.CardNumber, user.UserId);

        return Unit.Value;
    }
}
