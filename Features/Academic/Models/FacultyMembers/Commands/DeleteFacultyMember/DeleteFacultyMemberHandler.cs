using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.DeleteFacultyMember
{
    public sealed class DeleteFacultyMemberHandler
        : IRequestHandler<DeleteFacultyMemberCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IFacultyMemberProvider _provider;

        public DeleteFacultyMemberHandler(
            ApplicationDbContext context,
            IFacultyMemberProvider provider
        )
        {
            _context = context;
            _provider = provider;
        }

        public async Task<Unit> Handle(
            DeleteFacultyMemberCommand request,
            CancellationToken cancellationToken
        )
        {
            var faculty = await _provider.GetByIdAsync(request.Id);

            _context.FacultyMembers.Remove(faculty);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
