using Backend.Features.Academic.Models.Courses.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Courses.Queries.GetCourses
{
    public sealed class GetCourseHandler
        : IRequestHandler<GetCoursesQuery, PagedResultDto<CourseResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetCourseHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<CourseResponseDto>> Handle(
            GetCoursesQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.Courses.AsNoTracking();

            if (request.Title is not null)
                query = query.Where(c => EF.Functions.ILike(c.Title, $"{request.Title}%"));

            if (request.Code is not null)
                query = query.Where(c => EF.Functions.ILike(c.Code!, $"{request.Code}%"));

            if (request.Semester.HasValue)
                query = query.Where(c => c.Semester == request.Semester);

            if (request.DegreeId.HasValue)
                query = query.Where(c => c.DegreeId == request.DegreeId);

            var result = await query
                .OrderBy(c => c.Title)
                .ProjectToType<CourseResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
