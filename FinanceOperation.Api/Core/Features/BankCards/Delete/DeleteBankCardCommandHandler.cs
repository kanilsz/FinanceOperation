using FinanceOperation.Api.Core.Repositories;
using MediatR;

namespace FinanceOperation.Api.Core.Features.BankCards.Delete;

public class DeleteBankCardCommandHandler : IRequestHandler<DeleteBankCardCommand>
{
    private readonly IBankCardRepository _bankCardRepository;

    public DeleteBankCardCommandHandler(IBankCardRepository bankCardRepository)
    {
        _bankCardRepository = bankCardRepository;
    }

    public async Task<Unit> Handle(DeleteBankCardCommand request, CancellationToken cancellationToken)
    {
        await _bankCardRepository.Remove(request.CardNumber);
        return Unit.Value;
    }
}
