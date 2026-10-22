using Backend.Features.Academic.Models.CourseEnrollments.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Queries.GetCourseEnrollmentById
{
    public sealed class GetCourseEnrollmentByIdHandler
        : IRequestHandler<GetCourseEnrollmentByIdQuery, CourseEnrollmentResponseDto>
    {
        private readonly ICourseEnrollmentProvider _provider;

        public GetCourseEnrollmentByIdHandler(ICourseEnrollmentProvider provider)
        {
            _provider = provider;
        }

        public async Task<CourseEnrollmentResponseDto> Handle(
            GetCourseEnrollmentByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var enrollment = await _provider.GetByIdAsync(request.Id);
            return enrollment.Adapt<CourseEnrollmentResponseDto>();
        }
    }
}
