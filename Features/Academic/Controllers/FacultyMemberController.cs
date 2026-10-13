using Backend.Features.Academic.Models.FacultyMembers.Commands.CreateFacultyMember;
using Backend.Features.Academic.Models.FacultyMembers.Commands.DeleteFacultyMember;
using Backend.Features.Academic.Models.FacultyMembers.Commands.UpdateFacultyMember;
using Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMemberById;
using Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMembers;
using Backend.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyMemberController : BaseController
    {
        public FacultyMemberController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetFacultyMembersQuery request,
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
            GetFacultyMemberByIdQuery request = new() { Id = id };
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateFacultyMemberCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateFacultyMemberCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Faculty member has been updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteFacultyMemberCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Faculty member has been removed successfully.");
        }
    }
}
