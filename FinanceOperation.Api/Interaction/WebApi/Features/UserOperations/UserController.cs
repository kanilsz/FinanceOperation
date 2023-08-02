using FinanceOperation.Api.Core.Features.Identity;
using FinanceOperation.Api.Core.Features.UserData.GetUserData;
using FinanceOperation.Api.Core.Features.Users.AddBankCard;
using FinanceOperation.Api.Core.Features.Users.AddDiscountCard;
using FinanceOperation.Api.Core.Features.Users.DeleteBankCards;
using FinanceOperation.Api.Core.Features.Users.DeleteDiscountCards;
using FinanceOperation.Api.Core.Features.Users.GetUserCards;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Interactions.WebApi.Features.UserOperations;

[Route("/v1/users")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDataDto))]
    public async Task<ActionResult> GetUserData([FromRoute] int id) =>
         Ok(await _mediator.Send(new GetUserDataQuery(id)));


    [HttpGet("{userId}/cards")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CardsDto))]
    public async Task<ActionResult> GetUserCards([FromRoute] int userId)
    {
        return Ok(await _mediator.Send(new GetUserCardsQuery
        {
            UserId = userId
        }));
    }

    [HttpDelete("{userId}/bankCards/{cardNumber}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteUserBankCard([FromRoute] int userId, [FromRoute] string cardNumber)
    {
        await _mediator.Send(new DeleteUserBankCardCommand
        {
            UserId = userId,
            CardNumber = cardNumber
        });
        return NoContent();
    }

    [HttpDelete("{userId}/discountCards/{cardNumber}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteUserDiscountCard([FromRoute] int userId, [FromRoute] string cardNumber)
    {
        await _mediator.Send(new DeleteUserDiscountCardCommand
        {
            UserId = userId,
            CardNumber = cardNumber
        });
        return NoContent();
    }

    [HttpPost("{userId}/bankCards")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AddUserBankCard([FromRoute] int userId, [FromBody] AddUserCardRequest request)
    {
        await _mediator.Send(new AddUserBankCardCommand
        {
            UserId = userId,
            CardNumber = request.CardNumber!,
            Balance = request.Balance
        });
        return NoContent();
    }

    [HttpPost("{userId}/discountCards")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AddUserDiscountCard([FromRoute] int userId, [FromBody] AddUserCardRequest request)
    {
        await _mediator.Send(new AddUserDiscountCardCommand
        {
            UserId = userId,
            CardNumber = request.CardNumber!,
            Balance = request.Balance
        });
        return NoContent();
    }
}
