using Backend.Features.Users.Commands.ActiveUser;
using Backend.Features.Users.Commands.CreateUser;
using Backend.Features.Users.Commands.DeactiveUser;
using Backend.Features.Users.Commands.DeleteUser;
using Backend.Features.Users.Commands.UpdateUser;
using Backend.Features.Users.Queries.GetUserById;
using Backend.Features.Users.Queries.GetUsers;
using Backend.Shared.Common.Responses;
using Backend.Shared.Controllers;
using Backend.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Users.Controllers
{
    [Route("api/[controller]")]
    public sealed class UserController : BaseController
    {
        public UserController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult> GetUsersAsync(
            [FromQuery] GetUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetUserByIdAsync(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _mediator.Send(request, cancellationToken);

            if (user is null)
            {
                return BadRequest("User doesn't exist");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var userId = await _mediator.Send(request, cancellationToken);

                return CreatedAtAction(
                    nameof(GetUserByIdAsync),
                    new { userId },
                    new EntityCreatedResponse(userId)
                );
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUserAsync(
            DeleteUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var success = await _mediator.Send(request, cancellationToken);
            return success ? Ok("User has been deleted successfully") : NotFound();
        }

        [HttpPatch("update/username")]
        public async Task<ActionResult> UpdateUsernameAsync(
            UpdateUserUsernameCommand request,
            CancellationToken cancellationToken
        )
        {
            var success = await _mediator.Send(request, cancellationToken);
            return success ? Ok("Username has been updated successfully") : NotFound();
        }

        [HttpPatch("update/activate")]
        public async Task<ActionResult> ActivateUserAsync(
            ActivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var success = await _mediator.Send(request, cancellationToken);
            return success ? Ok("User has been activated successfully") : NotFound();
        }

        [HttpPatch("update/deactivate")]
        public async Task<ActionResult> DeactivateUserAsync(
            DeactivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            var success = await _mediator.Send(request, cancellationToken);
            return success ? Ok("User has been deactivated successfully") : NotFound();
        }
    }
}
