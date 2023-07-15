using FinanceOperation.Core.Features.Identity.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Features.Identities
{
    [Route("/v1/identities")]
    public class IdentityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> RegisterIdentity([FromBody] RegisterUserRequest request)
        {
            return Created("/v1", await _mediator.Send(new RegisterUserCommand
            {
                Email = request.Email,
                Password = request.Password,
                SecondName = request.SecondName,
                FirstName = request.FirstName
            }));
        }
    }

    public record RegisterUserRequest(string FirstName, string SecondName, string Email, string Password);
}
