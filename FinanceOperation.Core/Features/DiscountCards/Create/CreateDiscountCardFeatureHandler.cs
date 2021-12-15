using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.Create
{
    public class CreateDiscountCardFeatureHandler: IRequestHandler<CreateDiscountCardFeature, Unit>
    {
        private readonly IDiscountCardRepository _discountCardRepository;

        public CreateDiscountCardFeatureHandler(IDiscountCardRepository discountCardRepository)
        {
            _discountCardRepository = discountCardRepository;
        }

        public async Task<Unit> Handle(CreateDiscountCardFeature request, CancellationToken cancellationToken)
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
}
