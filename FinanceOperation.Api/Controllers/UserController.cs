using FinanceOperation.Api.Models;
using FinanceOperation.Core.Features.Users;
using FinanceOperation.Core.Features.Users.Create;
using FinanceOperation.Core.Features.Users.Delete;
using FinanceOperation.Core.Features.Users.GetUserCards;
using FinanceOperation.Core.Features.Users.GetUserInfo;
using FinanceOperation.Core.Features.Users.GetUsersInfo;
using FinanceOperation.Core.Features.Users.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Controllers
{
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

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(UserInfoDto))]
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
            await _mediator.Send(new DeleteUserCommand
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
            await _mediator.Send(new UpdateUserCommand
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserInfoDto))]
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
                BankCards = request.BankCards,
                DiscountCards = request.DiscountCards,
                Email = request.Email,
                SecondName = request.SecondName,
                FirstName = request.FirstName
            }));
        }
    }
}
