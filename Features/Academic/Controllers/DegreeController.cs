using Backend.Features.Academic.Models.Degrees.Commands.CreateDegree;
using Backend.Features.Academic.Models.Degrees.Commands.DeleteDegree;
using Backend.Features.Academic.Models.Degrees.Commands.UpdateDegree;
using Backend.Features.Academic.Models.Degrees.Queries.GetDegreeById;
using Backend.Features.Academic.Models.Degrees.Queries.GetDegrees;
using Backend.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : BaseController
    {
        public DegreeController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetDegreesQuery request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {
            GetDegreeByIdQuery request = new() { Id = id };
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateDegreeCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateDegreeCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteDegreeCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
