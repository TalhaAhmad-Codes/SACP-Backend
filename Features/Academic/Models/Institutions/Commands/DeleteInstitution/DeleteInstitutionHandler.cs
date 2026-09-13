using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Commands.DeleteInstitution
{
    public sealed class DeleteInstitutionHandler : IRequestHandler<DeleteInstitutionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;

        public DeleteInstitutionHandler(
            ApplicationDbContext context,
            IInstitutionProvider institutionProvider
        )
        {
            _context = context;
            _institutionProvider = institutionProvider;
        }

        public async Task<Unit> Handle(
            DeleteInstitutionCommand request,
            CancellationToken cancellationToken
        )
        {
            // Get institution by ID
            var institution = await _institutionProvider.GetByIdAsync(
                request.Id,
                cancellationToken
            );

            // Delete institution
            _context.Remove(institution);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
