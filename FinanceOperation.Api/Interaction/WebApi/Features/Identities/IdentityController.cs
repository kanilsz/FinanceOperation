using System.ComponentModel.DataAnnotations;
using FinanceOperation.Api.Core.Features.Identity;
using FinanceOperation.Api.Core.Features.Identity.Delete;
using FinanceOperation.Api.Core.Features.Identity.Get;
using FinanceOperation.Api.Core.Features.Identity.Register;
using FinanceOperation.Api.Core.Features.Identity.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Interactions.WebApi.Features.Identities;

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
            PhoneNumber = request.PhoneNumber,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
        }));
    }


    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserIdentityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserInfo([FromRoute] int userId)
    {
        return Ok(await _mediator.Send(new GetUserInfoQuery
        {
            UserId = userId
        }));
    }

    [HttpPatch("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUser([FromRoute] string userId, [FromBody] UpdateUserRequest request)
    {
        await _mediator.Send(new UpdateUserCommand
        {
            UserId = userId,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email
        });
        return NoContent();
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser([FromRoute] string userId)
    {
        await _mediator.Send(new DeleteUserCommand
        {
            UserId = userId
        });
        return NoContent();
    }
}

public record RegisterUserRequest()
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required, Compare("Password")]
    public string ConfirmPassword { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string PhoneNumber { get; set; }
}

public record UpdateUserRequest
{
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }
}
