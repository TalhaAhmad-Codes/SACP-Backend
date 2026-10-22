using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Utilities;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.UpdateCourseEnrollment
{
    public sealed class UpdateCourseEnrollmentHandler
        : IRequestHandler<UpdateCourseEnrollmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseEnrollmentProvider _provider;

        public UpdateCourseEnrollmentHandler(
            ApplicationDbContext context,
            ICourseEnrollmentProvider provider
        )
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            UpdateCourseEnrollmentCommand request,
            CancellationToken cancellationToken
        )
        {
            var enrollment = await _provider.GetByIdAsync(request.Id);

            if (
                enrollment.StudentId != request.StudentId
                || enrollment.CourseId != request.CourseId
            )
            {
                var alreadyEnrolled = await _provider.IsAlreadyEnrolledAsync(
                    request.StudentId,
                    request.CourseId
                );

                if (alreadyEnrolled)
                    throw new InvalidRequestException(Message.AlreadyExists("Course Enrollment"));
            }

            enrollment.Status = request.Status;
            enrollment.CourseId = request.CourseId;
            enrollment.SessionId = request.SessionId;
            enrollment.StudentId = request.StudentId;
            enrollment.MarkUpdated();

            _context.CourseEnrollments.Update(enrollment);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
