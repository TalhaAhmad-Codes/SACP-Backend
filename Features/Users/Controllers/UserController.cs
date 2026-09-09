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
        public async Task<IActionResult> GetUserByIdAsync(
            GetUserByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var user = await _mediator.Send(request, cancellationToken);
                return Ok(user);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(
            CreateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var user = await _mediator.Send(request, cancellationToken);
                return Ok(user);
            }
            catch (InvalidRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(
            DeleteUserCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("User has been deleted successfully");
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpPatch("update/username")]
        public async Task<IActionResult> UpdateUsernameAsync(
            UpdateUsernameCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("Username has been updated successfully");
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpPatch("update/activate")]
        public async Task<IActionResult> ActivateUserAsync(
            ActivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("User has been activated successfully");
            }
            catch (NotExistsException ex)
            {
                return NotFound();
            }
        }

        [HttpPatch("update/deactivate")]
        public async Task<IActionResult> DeactivateUserAsync(
            DeactivateUserCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("User has been deactivated successfully");
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }
    }
}
