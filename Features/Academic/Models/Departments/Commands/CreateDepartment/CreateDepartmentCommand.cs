using Backend.Features.Academic.Models.Departments.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Commands.CreateDepartment
{
    public sealed class CreateDepartmentCommand : IRequest<DepartmentResponse>
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public Guid InstitutionId { get; init; }
    }
}
