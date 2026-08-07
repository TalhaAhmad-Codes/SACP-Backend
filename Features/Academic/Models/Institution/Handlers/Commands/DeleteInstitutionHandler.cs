using Backend.Features.Academic.Models.Institution.Commands.DeleteInstitution;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Models.Institution.Handlers.Commands
{
    public sealed class DeleteInstitutionHandler : IRequestHandler<DeleteInstitutionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;

        public DeleteInstitutionHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider)
        {
            _context = context;
            _institutionProvider = institutionProvider;
        }

        public async Task<Unit> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
        {
            var institution = await _institutionProvider.GetByIdAsync(request.Id, cancellationToken);

            _context.Institutions.Remove(institution);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
