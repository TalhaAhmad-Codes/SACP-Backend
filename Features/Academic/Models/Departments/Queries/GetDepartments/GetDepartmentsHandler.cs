using Backend.Features.Academic.Models.Departments.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Departments.Queries.GetDepartments
{
    public sealed class GetDepartmentsHandler
        : IRequestHandler<GetDepartmentsQuery, PagedResultDto<DepartmentResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetDepartmentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<DepartmentResponse>> Handle(
            GetDepartmentsQuery request,
            CancellationToken cancellationToken
        )
        {
            // Get query
            var query = _context.Departments.AsNoTracking();

            // Applying filters
            if (request.Name is not null)
                query = query.Where(d => EF.Functions.ILike(d.Name, $"{request.Name}%"));

            if (request.InstitutionId.HasValue)
                query = query.Where(d => d.InstitutionId == request.InstitutionId.Value);

            // Perform pagination
            var departmentsResponse = await query
                .OrderBy(d => d.Name)
                .ProjectToType<DepartmentResponse>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return departmentsResponse;
        }
    }
}
