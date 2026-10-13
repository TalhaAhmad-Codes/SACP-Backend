using Backend.Features.Academic.Models.Students.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Students.Queries.GetStudents
{
    public sealed class GetStudentsHandler
        : IRequestHandler<GetStudentsQuery, PagedResultDto<StudentResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetStudentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<StudentResponseDto>> Handle(
            GetStudentsQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.Students.AsNoTracking();

            // Filteration
            if (request.Name is not null)
                query = query.Where(s => EF.Functions.ILike(s.FullName, $"{request.Name}%"));

            if (request.RegistrationNumber is not null)
                query = query.Where(s =>
                    EF.Functions.ILike(s.RegistrationNumber, $"{request.RegistrationNumber}%")
                );

            if (request.FromEnrollmentDate.HasValue)
                query = query.Where(s => s.EnrollmentDate >= request.FromEnrollmentDate);

            if (request.ToEnrollmentDate.HasValue)
                query = query.Where(s => s.EnrollmentDate <= request.ToEnrollmentDate);

            if (request.AcademicStatus.HasValue)
                query = query.Where(s => s.AcademicStatus == request.AcademicStatus);

            if (request.IsActive.HasValue)
                query = query.Where(s => s.IsActive == request.IsActive);

            if (request.DegreeId.HasValue)
                query = query.Where(s => s.DegreeId == request.DegreeId);

            if (request.DepartmentId.HasValue)
                query = query.Where(s => s.DepartmentId == request.DepartmentId);

            // Pagination
            var result = await query
                .OrderBy(s => s.FullName)
                .ProjectToType<StudentResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}
