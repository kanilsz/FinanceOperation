using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.Delete;

public class DeleteDiscountCardCommandHandler : IRequestHandler<DeleteDiscountCardCommand>
{
    private readonly IDiscountCardRepository _discountCardRepository;

    public DeleteDiscountCardCommandHandler(IDiscountCardRepository discountCardRepository)
    {
        _discountCardRepository = discountCardRepository;
    }

    public async Task<Unit> Handle(DeleteDiscountCardCommand request, CancellationToken cancellationToken)
    {
        await _discountCardRepository.Remove(request.CardNumber, cancellationToken);
        return Unit.Value;
    }
}
