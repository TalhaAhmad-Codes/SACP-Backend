using Backend.Features.Academic.Models.Institution.Commands.UpdateInstitution;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using MediatR;

namespace Backend.Features.Academic.Models.Institution.Handlers.Commands
{
    public sealed class UpdateInstitutionHandler : IRequestHandler<UpdateInstitutionCommand, Unit>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;

        public UpdateInstitutionHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider)
        {
            _context = context;
            _institutionProvider = institutionProvider;
        }

        public async Task<Unit> Handle(UpdateInstitutionCommand request, CancellationToken cancellationToken)
        {
            var institution = await _institutionProvider.GetByIdAsync(request.Id, cancellationToken);

            var existsByName = await _institutionProvider.ExistsByNameAsync(request.Name.Trim(), cancellationToken);

            if (existsByName)
                throw new NotExistsException("Institution already exists with given name");

            institution.Name = request.Name.Trim();
            _context.Institutions.Update(institution);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
