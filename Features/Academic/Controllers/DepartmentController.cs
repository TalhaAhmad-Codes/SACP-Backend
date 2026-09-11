using Backend.Features.Academic.Models.Departments.Commands.CreateDepartment;
using Backend.Features.Academic.Models.Departments.Commands.DeleteDepartment;
using Backend.Features.Academic.Models.Departments.Commands.UpdateDepartment;
using Backend.Features.Academic.Models.Departments.Queries.GetDepartmentById;
using Backend.Features.Academic.Models.Departments.Queries.GetDepartments;
using Backend.Shared.Controllers;
using Backend.Shared.Exceptions;
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
        public async Task<IActionResult> GetByIdAsync(
            [FromBody] GetDepartmentByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var department = await _mediator.Send(request, cancellationToken);
                return Ok(department);
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] CreateDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                return Ok(response);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(
            [FromBody] UpdateDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("Department has been updated successfully.");
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] DeleteDepartmentCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await _mediator.Send(request, cancellationToken);
                return Ok("Department has been deleted successfully.");
            }
            catch (NotExistsException)
            {
                return NotFound();
            }
        }
    }
}
