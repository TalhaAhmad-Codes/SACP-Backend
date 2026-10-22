using Backend.Features.Academic.Models.CourseEnrollments.Enums;
using Backend.Features.Academic.Models.CourseEnrollments.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Queries.GetCourseEnrollments
{
    public sealed class GetCourseEnrollmentsQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<CourseEnrollmentResponseDto>>
    {
        public CourseEnrollmentStatus? Status { get; init; }
        public Guid? CourseId { get; init; }
        public Guid? SessionId { get; init; }
        public Guid? StudentId { get; init; }
    }
}
