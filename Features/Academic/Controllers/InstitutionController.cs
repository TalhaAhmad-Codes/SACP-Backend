using Backend.Features.Academic.Models.Institutions.Commands.CreateInstitution;
using Backend.Features.Academic.Models.Institutions.Commands.DeleteInstitution;
using Backend.Features.Academic.Models.Institutions.Commands.UpdateInsitution;
using Backend.Features.Academic.Models.Institutions.Queries.GetInstitutionById;
using Backend.Features.Academic.Models.Institutions.Queries.GetInstitutions;
using Backend.Shared.Controllers;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class InstitutionController : BaseController
    {
        public InstitutionController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetInstitutionsQuery request,
            CancellationToken cancellationToken
        )
        {
            var institutions = await _mediator.Send(request, cancellationToken);
            return Ok(institutions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(
            GetInstitutionByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var institution = await _mediator.Send(request, cancellationToken);
                return Ok(institution);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateInstitutionCommand request,
            CancellationToken cancellationToken
        )
        {
            var institution = await _mediator.Send(request, cancellationToken);
            return Ok(institution);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateInstitutionCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var institution = await _mediator.Send(request, cancellationToken);
                return Ok(institution);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteInstitutionCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("Institution deleted successfully.");
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }
    }
}
