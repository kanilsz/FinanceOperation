using FinanceOperation.Api.InputModels;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.BankCards.Create;
using FinanceOperation.Core.Features.BankCards.GetByCardNumber;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Controllers
{
    [Route("/v1/bankcards")]
    public class BankCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cardNumber}")]
        public async Task<ActionResult> GetByCardNumber([FromRoute] string cardNumber)
        {
            BankCardDto response = await _mediator.Send(new GetByCardNumberQueryFeature
            {
                CardNumber = cardNumber
            });

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBankCard([FromBody] CreateBankCardRequest request)
        {
            return Ok(await _mediator.Send(new CreateBankCardFeature
            {
                CardNumber = request.CardNumber,
                Balance = request.Balance
            }));
        }
    }
}
