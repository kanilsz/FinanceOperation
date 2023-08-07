using FinanceOperation.Api.Core.Features.Propositions;
using FinanceOperation.Api.Core.Features.Propositions.Add.Credit;
using FinanceOperation.Api.Core.Features.Propositions.Add.Deposit;
using FinanceOperation.Api.Core.Features.Propositions.Get.CreditDetails;
using FinanceOperation.Api.Core.Features.Propositions.Get.DepositDetails;
using FinanceOperation.Api.Core.Features.Propositions.GetList.Credits;
using FinanceOperation.Api.Core.Features.Propositions.GetList.Deposits;
using FinanceOperation.Api.Core.Features.Propositions.Remove.Credit;
using FinanceOperation.Api.Core.Features.Propositions.Remove.Deposit;
using FinanceOperation.Api.Core.Features.Propositions.Update.Credits;
using FinanceOperation.Api.Core.Features.Propositions.Update.Deposit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceOperation.Api.Interaction.WebApi.Features.Propositions;

[Route("/v1/propositions")]
public class PropositionController : ControllerBase
{
    private readonly IMediator _mediator;

    public PropositionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("credits")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreditPropositionDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AddCreditProposition([FromBody] AddPropositionRequest request)
    {
        var result = await _mediator.Send(new AddCreditPropositionCommand
        {
            PropositionNumber = request.PropositionNumber,
            Summary = request.Summary,
            Percentage = request.Percentage,
            UserId = request.UserId
        });

        return Created($"/v1/propositions/credits/{result.Id}", result);
    }


    [HttpPost("deposits")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DepositPropositionDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AddDepositProposition([FromBody] AddPropositionRequest request)
    {
        var result = await _mediator.Send(new AddDepositPropositionCommand
        {
            PropositionNumber = request.PropositionNumber,
            Summary = request.Summary,
            Percentage = request.Percentage,
            UserId = request.UserId
        });

        return Created($"/v1/propositions/deposits/{result.Id}", result);
    }

    [HttpGet("credits")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CreditPropositionDto>))]
    public async Task<ActionResult<IEnumerable<CreditPropositionDto>>> GetCreditPropositions([FromQuery]int? userId) =>
         Ok(await _mediator.Send(new GetCreditPropositionsQuery(userId)));

    [HttpGet("deposits")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DepositPropositionDto>))]
    public async Task<ActionResult<IEnumerable<DepositPropositionDto>>> GetDepositPropositions([FromQuery] int? userId) =>
         Ok(await _mediator.Send(new GetDepositPropositionsQuery(userId)));

    [HttpGet("credits/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreditPropositionDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GeCreditPropositonsList([FromRoute] int id) =>
         Ok(await _mediator.Send(new GetCreditPropositionDetailsQuery(id)));


    [HttpGet("deposits/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreditPropositionDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetPropositionsList([FromRoute] int id) =>
         Ok(await _mediator.Send(new GetDepositPropositionDetailsQuery(id)));


    [HttpPatch("credits/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateCreditProposition(
        [FromRoute] int id,
        [FromBody] UpdatePropositionRequest request)
    {
        await _mediator.Send(new UpdateCreditPropositionCommand
        {
            Id = id,
            PropositionNumber = request.PropositionNumber,
            Summary = request.Summary,
            Percentage = request.Percentage,
            UserId = request.UserId
        });
        return NoContent();
    }

    [HttpPatch("deposits/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateDepositProposition(
        [FromRoute] int id,
        [FromBody] UpdatePropositionRequest request)
    {
        await _mediator.Send(new UpdateDepositPropositionCommand
        {
            Id = id,
            PropositionNumber = request.PropositionNumber,
            Summary = request.Summary,
            Percentage = request.Percentage,
            UserId = request.UserId
        });
        return NoContent();
    }

    [HttpDelete("credits/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveCreditProposition([FromRoute] int id)
    {
        await _mediator.Send(new RemoveCreditPropositionCommand
        {
            Id = id
        });
        return NoContent();
    }

    [HttpDelete("deposits/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveDepositProposition([FromRoute] int id)
    {
        await _mediator.Send(new RemoveDepositPropositionCommand
        {
            Id = id
        });
        return NoContent();
    }
}

public record AddPropositionRequest()
{
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}

public record UpdatePropositionRequest
{
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
    public DateTime EndDateTime { get; set; }
}
