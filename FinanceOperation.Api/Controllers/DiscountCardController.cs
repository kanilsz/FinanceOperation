using FinanceOperation.Api.InputModels;
using FinanceOperation.Core.Features.DiscountCards;
using FinanceOperation.Core.Features.DiscountCards.Create;
using FinanceOperation.Core.Features.DiscountCards.Delete;
using FinanceOperation.Core.Features.DiscountCards.GetByDiscountNumber;
using FinanceOperation.Core.Features.DiscountCards.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Controllers
{
    [Route("/v1/discountcards")]
    public class DiscountCardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountCardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscountCardDto))]
        public async Task<ActionResult> GetBankCards()
        {
            return Ok(await _mediator.Send(new GetDiscountCardListFeature()));
        }

        [HttpGet("{cardNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscountCardDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByCardNumber([FromRoute] string cardNumber)
        {
            var response = await _mediator.Send(new GetByDiscountNumberQueryFeature
            {
                CardNumber = cardNumber
            });

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateBankCard([FromBody] CreateDiscountCardRequest request)
        {
            return Created("/v1/discountcards", await _mediator.Send(new CreateDiscountCardFeature
            {
                CardNumber = request.CardNumber,
                Balance = request.Balance
            }));
        }

        [HttpDelete("{cardNumber}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteBankCard([FromRoute] string cardNumber)
        {
            await _mediator.Send(new DeleteDiscountCardFeature
            {
                CardNumber = cardNumber
            });

            return NoContent();
        }
    }
}
