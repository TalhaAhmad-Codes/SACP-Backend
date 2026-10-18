using Backend.Features.Academic.Models.Courses.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Queries.GetCourseById
{
    public sealed class GetCourseByIdHandler
        : IRequestHandler<GetCourseByIdQuery, CourseResponseDto>
    {
        private readonly ICourseProvider _provider;

        public GetCourseByIdHandler(ICourseProvider provider)
        {
            _provider = provider;
        }

        public async Task<CourseResponseDto> Handle(
            GetCourseByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var course = await _provider.GetByIdAsync(request.Id);
            return course.Adapt<CourseResponseDto>();
        }
    }
}
