using FinanceOperation.Api.Core.Repositories;
using FinanceOperation.Api.Domain.Cards;
using FinanceOperation.Api.Domain.Users;
using FinanceOperation.Api.Infrastructure.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.Users.AddDiscountCard;

public class AddUserDiscountCardCommandHandler : IRequestHandler<AddUserDiscountCardCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IDiscountCardRepository _discountCardRepository;

    public AddUserDiscountCardCommandHandler(IUserRepository userRepository, IDiscountCardRepository discountCardRepository)
    {
        _userRepository = userRepository;
        _discountCardRepository = discountCardRepository;
    }

    public async Task Handle(AddUserDiscountCardCommand request, CancellationToken cancellationToken)
    {
        UserIdentity user = await _userRepository.GetUser(request.UserId)
            ?? throw new Exception($"UserId {request.UserId} is not found");

        await _discountCardRepository.Create(
            new DiscountCard
            {
                Balance = request.Balance,
                UserId = user.UserId,
                CardNumber = request.CardNumber
            });

        return;
    }
}
