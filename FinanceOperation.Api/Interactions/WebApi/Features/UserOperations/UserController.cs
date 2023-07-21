using FinanceOperation.Core.Features.Users;
using FinanceOperation.Core.Features.Users.AddBankCard;
using FinanceOperation.Core.Features.Users.AddDiscountCard;
using FinanceOperation.Core.Features.Users.Create;
using FinanceOperation.Core.Features.Users.Delete;
using FinanceOperation.Core.Features.Users.DeleteBankCards;
using FinanceOperation.Core.Features.Users.DeleteDiscountCards;
using FinanceOperation.Core.Features.Users.GetUserCards;
using FinanceOperation.Core.Features.Users.GetUserInfo;
using FinanceOperation.Core.Features.Users.GetUsersInfo;
using FinanceOperation.Core.Features.Users.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("{userId}/cards")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CardsDto))]
    public async Task<ActionResult> GetUserCards([FromRoute] string userId)
    {
        return Ok(await _mediator.Send(new GetUserCardsQuery
        {
            UserId = userId
        }));
    }

    [HttpDelete("{userId}/bankCards/{cardNumber}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteUserBankCard([FromRoute] string userId, [FromRoute] string cardNumber)
    {
        _ = await _mediator.Send(new DeleteUserBankCardCommand
        {
            UserId = userId,
            CardNumber = cardNumber
        });
        return NoContent();
    }

    [HttpDelete("{userId}/discountCards/{cardNumber}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteUserDiscountCard([FromRoute] string userId, [FromRoute] string cardNumber)
    {
        _ = await _mediator.Send(new DeleteUserDiscountCardCommand
        {
            UserId = userId,
            CardNumber = cardNumber
        });
        return NoContent();
    }

    [HttpPost("{userId}/bankCards")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AddUserBankCard([FromRoute] string userId, [FromBody] AddUserCardRequest request)
    {
        _ = await _mediator.Send(new AddUserBankCardCommand
        {
            UserId = userId,
            CardNumber = request.CardNumber!,
            Balance = request.Balance
        });
        return NoContent();
    }

    [HttpPost("{userId}/discountCards")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> AddUserDiscountCard([FromRoute] string userId, [FromBody] AddUserCardRequest request)
    {
        _ = await _mediator.Send(new AddUserDiscountCardCommand
        {
            UserId = userId,
            CardNumber = request.CardNumber!,
            Balance = request.Balance
        });
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UserIdentityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUsersInfo()
    {
        return Ok(await _mediator.Send(new GetUsersInfoQuery()));
    }

    [HttpDelete("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser([FromRoute] string id)
    {
        _ = await _mediator.Send(new DeleteUserCommand
        {
            Id = id
        });
        return NoContent();
    }

    [HttpPatch("{id}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUser([FromRoute] string id, [FromBody] UpdateUserRequest request)
    {
        _ = await _mediator.Send(new UpdateUserCommand
        {
            Id = id,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email
        });
        return NoContent();
    }

    [HttpGet("{userId}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserIdentityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserInfo([FromRoute] string userId)
    {
        return Ok(await _mediator.Send(new GetUserInfoQuery
        {
            UserId = userId
        }));
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        return Created("/v1/user", await _mediator.Send(new CreateUserCommand
        {
            Email = request.Email,
            SecondName = request.SecondName,
            FirstName = request.FirstName
        }));
    }
}
