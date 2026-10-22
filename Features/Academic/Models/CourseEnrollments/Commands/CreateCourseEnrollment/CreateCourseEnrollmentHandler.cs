using Backend.Features.Academic.Models.CourseEnrollments.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.CreateCourseEnrollment
{
    public sealed class CreateCourseEnrollmentHandler
        : IRequestHandler<CreateCourseEnrollmentCommand, CourseEnrollmentResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseEnrollmentProvider _provider;

        public CreateCourseEnrollmentHandler(
            ApplicationDbContext context,
            ICourseEnrollmentProvider provider
        )
        {
            _context = context;
            _provider = provider;
        }

        public async Task<CourseEnrollmentResponseDto> Handle(
            CreateCourseEnrollmentCommand request,
            CancellationToken cancellationToken
        )
        {
            bool alreadyEnrolled = await _provider.IsAlreadyEnrolledAsync(
                request.StudentId,
                request.CourseId
            );

            if (alreadyEnrolled)
                throw new InvalidRequestException(Message.AlreadyExists("Student Enrollment"));

            CourseEnrollment enrollment = new()
            {
                Status = request.Status,
                CourseId = request.CourseId,
                SessionId = request.SessionId,
                StudentId = request.StudentId,
            };

            await _context.CourseEnrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync(cancellationToken);

            return enrollment.Adapt<CourseEnrollmentResponseDto>();
        }
    }
}
