using Backend.Features.Users.Commands.ActiveUser;
using Backend.Features.Users.Commands.CreateUser;
using Backend.Features.Users.Commands.DeactiveUser;
using Backend.Features.Users.Commands.DeleteUser;
using Backend.Features.Users.Commands.UpdateUser.Username;
using Backend.Features.Users.Queries.GetUserById;
using Backend.Features.Users.Queries.GetUsers;
using Backend.Shared.Controllers;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Users.Controllers
{
    [Route("api/users")]
    public sealed class UserController : BaseController
    {
        public UserController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync(
            [FromQuery] GetUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserByIdAsync(CancellationToken cancellationToken)
        {
            var request = new GetUserByIdQuery
            {
                Id = Guid.Parse(RouteData.Values["id"]?.ToString() ?? string.Empty),
            };

            var user = await _mediator.Send(request, cancellationToken);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _mediator.Send(request, cancellationToken);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(
            DeleteUserCommand request,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("User has been deleted successfully");
        }

        [HttpPatch("update/username")]
        public async Task<IActionResult> UpdateUsernameAsync(
            UpdateUsernameCommand request,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Username has been updated successfully");
        }

        [HttpPatch("update/activate")]
        public async Task<IActionResult> ActivateUserAsync(
            ActivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("User has been activated successfully");
        }

        [HttpPatch("update/deactivate")]
        public async Task<IActionResult> DeactivateUserAsync(
            DeactivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("User has been deactivated successfully");
        }
    }
}
