using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Commands.UpdateDepartment
{
    public sealed class UpdateDepartmentCommand : BaseDto, IRequest<Unit>
    {
        public string Name { get; init; }
        public string? Description { get; init; }
    }
}
