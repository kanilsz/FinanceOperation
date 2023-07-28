using FinanceOperation.Api.Core.Features.Propositions;
using FinanceOperation.Api.Core.Features.Propositions.Add;
using FinanceOperation.Api.Core.Features.Propositions.Get;
using FinanceOperation.Api.Core.Features.Propositions.Get.CreditDetails;
using FinanceOperation.Api.Core.Features.Propositions.Get.DepositDetails;
using FinanceOperation.Api.Core.Features.Propositions.GetList;
using FinanceOperation.Api.Core.Features.Propositions.GetList.Credits;
using FinanceOperation.Api.Core.Features.Propositions.GetList.Deposits;
using FinanceOperation.Api.Core.Features.Propositions.Remove;
using FinanceOperation.Api.Core.Features.Propositions.Update;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> AddProposition([FromQuery] string type, [FromBody] AddPropositionRequest request)
    {
        return Created("/v1", await _mediator.Send(new AddPropositionCommand
        {
            Type = type,
            PropositionNumber = request.PropositionNumber,
            Summary = request.Summary,
            Percentage = request.Percentage,
            UserId = request.UserId
        }));
    }

    [HttpGet("credits")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CreditPropositionDto>))]
    public async Task<ActionResult<IEnumerable<CreditPropositionDto>>> GetCreditPropositions() =>
         Ok(await _mediator.Send(new GetCreditPropositionsQuery()));

    [HttpGet("deposits")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DepositPropositionDto>))]
    public async Task<ActionResult<IEnumerable<DepositPropositionDto>>> GetDepositPropositions() =>
         Ok(await _mediator.Send(new GetDepositPropositionsQuery()));

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


    [HttpPatch("{propositionId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateProposition(
        [FromRoute] int propositionId,
        [FromQuery] string type,
        [FromBody] UpdatePropositionRequest request)
    {
        await _mediator.Send(new UpdatePropositionCommand
        {
            PropositionId = propositionId,
            Type = type,
            PropositionNumber = request.PropositionNumber,
            Summary = request.Summary,
            Percentage = request.Percentage,
            UserId = request.UserId
        });
        return NoContent();
    }

    [HttpDelete("{propositionId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveProposition([FromRoute] int propositionId)
    {
        await _mediator.Send(new RemovePropositionCommand
        {
            Id = propositionId
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
}

public record UpdatePropositionRequest
{
    public int? UserId { get; set; }
    public string PropositionNumber { get; set; }
    public decimal Summary { get; set; }
    public double Percentage { get; set; }
}
