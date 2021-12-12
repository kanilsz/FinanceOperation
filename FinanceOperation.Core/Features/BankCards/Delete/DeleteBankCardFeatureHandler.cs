using FinanceOperation.Core.Repositories;
using MediatR;

namespace FinanceOperation.Core.Features.BankCards.Delete
{
    public class DeleteBankCardFeatureHandler : IRequestHandler<DeleteBankCardFeature>
    {
        private readonly IBankCardRepository _bankCardRepository;

        public DeleteBankCardFeatureHandler(IBankCardRepository bankCardRepository)
        {
            _bankCardRepository = bankCardRepository;
        }

        public async Task<Unit> Handle(DeleteBankCardFeature request, CancellationToken cancellationToken)
        {
            await _bankCardRepository.Remove(request.CardNumber);
            return Unit.Value;
        }
    }
}
