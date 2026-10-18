using Backend.Features.Academic.Models.Courses.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Commands.CreateCourse
{
    public sealed class CreateCourseHandler
        : IRequestHandler<CreateCourseCommand, CourseResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseProvider _provider;

        public CreateCourseHandler(ApplicationDbContext context, ICourseProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<CourseResponseDto> Handle(
            CreateCourseCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.Code is not null)
            {
                var existsByCode = await _provider.ExistsByCodeAsync(
                    request.Code,
                    cancellationToken
                );

                if (existsByCode)
                    throw new InvalidRequestException(Message.AlreadyExists("Code"));
            }

            Course course = new()
            {
                Title = request.Title,
                Code = request.Code,
                CreditHours = request.CreditHours,
                Semester = request.Semester,
                DegreeId = request.DegreeId,
            };

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync(cancellationToken);

            return course.Adapt<CourseResponseDto>();
        }
    }
}
