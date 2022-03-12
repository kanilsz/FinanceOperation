using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.DiscountCards.Delete
{
    public class DeleteDiscountCardFeatureHandler : IRequestHandler<DeleteDiscountCardFeature>
    {
        private readonly IDiscountCardRepository _discountCardRepository;

        public DeleteDiscountCardFeatureHandler(IDiscountCardRepository discountCardRepository)
        {
            _discountCardRepository = discountCardRepository;
        }

        public async Task<Unit> Handle(DeleteDiscountCardFeature request, CancellationToken cancellationToken)
        {
            await _discountCardRepository.Remove(request.CardNumber);
            return Unit.Value;
        }
    }
}
