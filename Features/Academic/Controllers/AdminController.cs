using Backend.Features.Academic.Models.Admins.Commands.CreateAdmin;
using Backend.Features.Academic.Models.Admins.Commands.DeleteAdmin;
using Backend.Features.Academic.Models.Admins.Commands.UpdateAdmin;
using Backend.Features.Academic.Models.Admins.Queries.GetAdminById;
using Backend.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class AdminController : BaseController
    {
        public AdminController(IMediator mediator)
            : base(mediator) { }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        )
        {
            GetAdminByIdQuery query = new() { Id = id };

            var admin = await _mediator.Send(query, cancellationToken);
            return Ok(admin);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateAdminCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateAdminCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Admin has been updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteAdminCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Admin has been deleted successfully.");
        }
    }
}
