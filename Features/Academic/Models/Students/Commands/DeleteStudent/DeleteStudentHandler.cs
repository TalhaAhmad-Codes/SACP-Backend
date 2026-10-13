using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Commands.DeleteStudent
{
    public sealed class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IStudentProvider _provider;

        public DeleteStudentHandler(ApplicationDbContext context, IStudentProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteStudentCommand request,
            CancellationToken cancellationToken
        )
        {
            var student = await _provider.GetByIdAsync(request.Id);

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
