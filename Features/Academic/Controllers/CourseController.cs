using Backend.Features.Academic.Models.Courses.Commands.CreateCourse;
using Backend.Features.Academic.Models.Courses.Commands.DeleteCourse;
using Backend.Features.Academic.Models.Courses.Commands.UpdateCourse;
using Backend.Features.Academic.Models.Courses.Queries.GetCourseById;
using Backend.Features.Academic.Models.Courses.Queries.GetCourses;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class CourseController : BaseController
    {
        public CourseController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetCoursesQuery request,
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
            GetCourseByIdQuery request = new() { Id = id };
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateCourseCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateCourseCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok(Message.Updated("Course"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteCourseCommand request,
            CancellationToken cancellationToken = default
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok(Message.Removed("Course"));
        }
    }
}
