using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.Create;

public class CreateDiscountCardCommandHandler : IRequestHandler<CreateDiscountCardCommand, Unit>
{
    private readonly IDiscountCardRepository _discountCardRepository;

    public CreateDiscountCardCommandHandler(IDiscountCardRepository discountCardRepository)
    {
        _discountCardRepository = discountCardRepository;
    }

    public async Task<Unit> Handle(CreateDiscountCardCommand request, CancellationToken cancellationToken)
    {
        DiscountCard discountCard = new()
        {
            CardNumber = request.CardNumber,
            Balance = request.Balance
        };
        await _discountCardRepository.Create(discountCard, cancellationToken);

        return Unit.Value;
    }
}
