using Backend.Features.Academic.Commands.Institution.UpdateInstitution;
using Backend.Features.Academic.Queries.Institution.GetInstitution;
using Backend.Shared.Controllers;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers;

[Route("api/Institutions")]
public sealed class InstitutionController : BaseController
{
    public InstitutionController(IMediator mediator) : base(mediator) { }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(GetInstitutionByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        catch (NotExistsException)
        {
            return NotFound();
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateInstitutionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Institution has been updated successfully");
        }
        catch (NotExistsException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
