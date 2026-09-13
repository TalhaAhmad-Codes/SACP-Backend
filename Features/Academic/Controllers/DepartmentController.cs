using Backend.Features.Academic.Models.Departments.Commands.CreateDepartment;
using Backend.Features.Academic.Models.Departments.Commands.DeleteDepartment;
using Backend.Features.Academic.Models.Departments.Commands.UpdateDepartment;
using Backend.Features.Academic.Models.Departments.Queries.GetDepartmentById;
using Backend.Features.Academic.Models.Departments.Queries.GetDepartments;
using Backend.Shared.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Features.Academic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        public DepartmentController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] GetDepartmentsQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(CancellationToken cancellationToken)
        {
            var request = new GetDepartmentByIdQuery
            {
                Id = Guid.Parse(RouteData.Values["id"]?.ToString() ?? string.Empty),
            };

            var department = await _mediator.Send(request, cancellationToken);
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Department has been updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(request, cancellationToken);
            return Ok("Department has been deleted successfully.");
        }
    }
}
