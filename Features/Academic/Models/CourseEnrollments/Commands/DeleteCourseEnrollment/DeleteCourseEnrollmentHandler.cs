using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.CourseEnrollments.Commands.DeleteCourseEnrollment
{
    public sealed class DeleteCourseEnrollmentHandler
        : IRequestHandler<DeleteCourseEnrollmentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseEnrollmentProvider _provider;

        public DeleteCourseEnrollmentHandler(
            ApplicationDbContext context,
            ICourseEnrollmentProvider provider
        )
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteCourseEnrollmentCommand request,
            CancellationToken cancellationToken
        )
        {
            var enrollment = await _provider.GetByIdAsync(request.Id);

            _context.CourseEnrollments.Remove(enrollment);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
