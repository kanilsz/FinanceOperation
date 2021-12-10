using FinanceOperation.API.Core.Features.BankCards.Create;
using FinanceOperation.API.Core.Features.BankCards.GetByCardNumber;
using FinanceOperation.API.Domain.Cards;
using FinanceOperation.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.API.Controllers
{
    [Route("/v1/bankcards")]
    public class BankCardController : ControllerBase
    {

        private readonly ILogger<BankCardController> _logger;
        private readonly IMediator _mediator;

        public BankCardController(ILogger<BankCardController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{cardNumber}")]
        public async Task<ActionResult> GetByCardNumber([FromRoute] string cardNumber)
        {
            //TODO: SHOULD BE DTO
            BankCard response = await _mediator.Send(new GetBankCardQueryFeature
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
