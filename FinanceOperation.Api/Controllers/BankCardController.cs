using FinanceOperation.Api.InputModels;
using FinanceOperation.Core.Features.BankCards;
using FinanceOperation.Core.Features.BankCards.Create;
using FinanceOperation.Core.Features.BankCards.Delete;
using FinanceOperation.Core.Features.BankCards.GetByCardNumber;
using FinanceOperation.Core.Features.BankCards.GetList;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BankCardDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByCardNumber([FromRoute] string cardNumber)
        {
           var response =  await _mediator.Send(new GetByCardNumberQueryFeature
            {
                CardNumber = cardNumber
            });

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateBankCard([FromBody] CreateBankCardRequest request)
        {
            return Created("/v1/bankcards", await _mediator.Send(new CreateBankCardFeature
            {
                CardNumber = request.CardNumber,
                Balance = request.Balance
            }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BankCardDto))]
        public async Task<ActionResult> GetBankCards()
        {
            return Ok(await _mediator.Send(new GetBankCardListFeature()));
        }

        [HttpDelete("{cardNumber}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBankCard([FromRoute] string cardNumber)
        {
            await _mediator.Send(new DeleteBankCardFeature
            {
                CardNumber = cardNumber
            });

            return NoContent();
        }
    }
}
