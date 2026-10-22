using Backend.Features.Academic.Models.CourseEnrollments.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.CourseEnrollments.Queries.GetCourseEnrollments
{
    public sealed class GetCourseEnrollmentHandler
        : IRequestHandler<GetCourseEnrollmentsQuery, PagedResultDto<CourseEnrollmentResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetCourseEnrollmentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<CourseEnrollmentResponseDto>> Handle(
            GetCourseEnrollmentsQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.CourseEnrollments.AsNoTracking();

            if (request.Status.HasValue)
                query = query.Where(e => e.Status == request.Status);

            if (request.CourseId.HasValue)
                query = query.Where(e => e.CourseId == request.CourseId);

            if (request.SessionId.HasValue)
                query = query.Where(e => e.SessionId == request.SessionId);

            if (request.StudentId.HasValue)
                query = query.Where(e => e.StudentId == request.StudentId);

            var result = await query
                .ProjectToType<CourseEnrollmentResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
