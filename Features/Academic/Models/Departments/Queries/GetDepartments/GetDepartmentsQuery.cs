using Backend.Features.Academic.Models.Departments.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Queries.GetDepartments
{
    public sealed class GetDepartmentsQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<DepartmentResponse>>
    {
        public Guid? InstitutionId { get; init; }
        public string? Name { get; init; }
    }
}
