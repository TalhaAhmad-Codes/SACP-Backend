using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Commands.UpdateInsitution
{
    public sealed class UpdateInstitutionHandler : IRequestHandler<UpdateInstitutionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;

        public UpdateInstitutionHandler(ApplicationDbContext context, IInstitutionProvider provider)
        {
            _context = context;
            _institutionProvider = provider;
        }

        public async Task<Unit> Handle(
            UpdateInstitutionCommand request,
            CancellationToken cancellationToken
        )
        {
            // Get institution
            var institution = await _institutionProvider.GetByIdAsync(
                request.Id,
                cancellationToken
            );

            // Check if updated name is unique
            var existsByName = await _institutionProvider.ExistsByNameAsync(
                request.Name,
                cancellationToken
            );

            if (existsByName)
            {
                throw new InvalidRequestException("Institution of given name already exists.");
            }

            // Update the institution
            institution.Name = request.Name;
            institution.MarkUpdated();

            _context.Institutions.Update(institution);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
