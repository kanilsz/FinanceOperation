using FinanceOperation.Api.InputModels;
using FinanceOperation.Core.Features.Users;
using FinanceOperation.Core.Features.Users.Create;
using FinanceOperation.Core.Features.Users.GetUserInfo;
using FinanceOperation.Core.Features.Users.GetUsersInfo;
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

        //[HttpGet("{userId}/bankcards")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BankCardDto))]
        //public async Task<ActionResult> GetUserBankCards([FromRoute] string userId)
        //{
        //    return Ok(await _mediator.Send());
        //}

        //[HttpGet("{userId}/discountcards")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DiscountCardDto))]
        //public async Task<ActionResult> GetUserDiscountCards([FromRoute] string userId)
        //{
        //    return Ok(await _mediator.Send());
        //}

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserInfoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetUsersInfo()
        {
            return Ok(await _mediator.Send(new GetUsersInfoQuery()));
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
        public async Task<ActionResult> CreateBankCard([FromBody] CreateUserRequest request)
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
