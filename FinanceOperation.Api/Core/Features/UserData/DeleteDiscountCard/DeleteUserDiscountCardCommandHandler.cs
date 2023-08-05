using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Users;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.DeleteDiscountCards;

public record DeleteUserDiscountCardCommand : IRequest
{
    public int UserId { get; set; }
    public string CardNumber { get; set; }
}

public class DeleteUserDiscountCardCommandHandler : IRequestHandler<DeleteUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IDiscountCardRepository _discountCardRepository;

    public DeleteUserDiscountCardCommandHandler(IUserRepository userRepository, IDiscountCardRepository discountCardRepository)
    {
        _userRepository = userRepository;
        _discountCardRepository = discountCardRepository;
    }

    public async Task Handle(DeleteUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId);

        await _discountCardRepository.Remove(request.CardNumber, user.Id);

        return;
    }
}
