using FinanceOperation.Core.Features.Transactions.Create;
using FinanceOperation.Core.Features.Transactions.Delete;
using FinanceOperation.Core.Features.Transactions.GetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Features.Transactions;

[Route("v1/transactions")]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserIncomeOutcome))]
    public async Task<ActionResult> GetUserTransactions([FromRoute] string userId)
    {
        return Ok(await _mediator.Send(new GetTransactionsByUserIdQuery
        {
            UserId = userId
        }));
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUserTransactions([FromRoute] string userId)
    {
        _ = await _mediator.Send(new DeleteTransactionCommand
        {
            UserId = userId
        });
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateUserTransactions([FromBody] CreateUserTransactionRequest request)
    {
        return Created("/v1/transactions", await _mediator.Send(new CreateTransactionCommand
        {
            BankName = request.BankName,
            Summary = request.Summary,
            UserId = request.UserId
        }));
    }
}
