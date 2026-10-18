using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Courses.Commands.DeleteCourse
{
    public sealed class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseProvider _provider;

        public DeleteCourseHandler(ApplicationDbContext context, ICourseProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteCourseCommand request,
            CancellationToken cancellationToken
        )
        {
            var course = await _provider.GetByIdAsync(request.Id);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
