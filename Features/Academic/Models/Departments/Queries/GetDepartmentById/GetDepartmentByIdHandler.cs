using Backend.Features.Academic.Models.Departments.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Departments.Queries.GetDepartmentById
{
    public sealed class GetDepartmentByIdHandler
        : IRequestHandler<GetDepartmentByIdQuery, DepartmentResponse>
    {
        private readonly IDepartmentProvider _departmentProvider;

        public GetDepartmentByIdHandler(IDepartmentProvider departmentProvider)
        {
            _departmentProvider = departmentProvider;
        }

        public async Task<DepartmentResponse> Handle(
            GetDepartmentByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            // Get department
            var department = await _departmentProvider.GetByIdAsync(request.Id, cancellationToken);

            // Return response
            return department.Adapt<DepartmentResponse>();
        }
    }
}
