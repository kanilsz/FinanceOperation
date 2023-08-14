using System.ComponentModel.DataAnnotations;
using FinanceOperation.Api.Core.Features.Identity;
using FinanceOperation.Api.Core.Features.Identity.Delete;
using FinanceOperation.Api.Core.Features.Identity.Get;
using FinanceOperation.Api.Core.Features.Identity.Login;
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

    [HttpPost("register")]
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

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> LoginIdentity([FromBody] LoginUserRequest request)
    {
        await _mediator.Send(new LoginUserCommand
        {
            Email = request.Email,
            Password = request.Password,
        });
        return Ok();
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserIdentityDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUserInfo([FromRoute] int id)
    {
        return Ok(await _mediator.Send(new GetUserInfoQuery
        {
            Id = id
        }));
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateUser([FromRoute] string id, [FromBody] UpdateUserRequest request)
    {
        await _mediator.Send(new UpdateUserCommand
        {
            Id = id,
            FirstName = request.FirstName,
            SecondName = request.SecondName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Password = request.Password,
            IsDeleted = request.IsDeleted
        });
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteUser([FromRoute] int id)
    {
        await _mediator.Send(new DeleteUserCommand
        {
            Id = id
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

public record LoginUserRequest()
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}

public record UpdateUserRequest
{
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Password { get; set; }

    public bool? IsDeleted { get; set; }
}
