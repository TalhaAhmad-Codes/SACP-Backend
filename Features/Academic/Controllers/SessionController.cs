using Backend.Features.Academic.Models.Sessions.Commands.CreateSession;
using Backend.Features.Academic.Models.Sessions.Commands.DeleteSession;
using Backend.Features.Academic.Models.Sessions.Commands.UpdateSession;
using Backend.Features.Academic.Models.Sessions.Queries.GetSessionById;
using Backend.Features.Academic.Models.Sessions.Queries.GetSessions;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class SessionController : BaseController
    {
        public SessionController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetSessionsQuery request,
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
            GetSessionByIdQuery request = new() { Id = id };

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateSessionCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateSessionCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok(Message.Updated("Session"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteSessionCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok(Message.Removed("Session"));
        }
    }
}
