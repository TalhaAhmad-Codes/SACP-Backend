using Backend.Features.Academic.Models.Institutions.Responses;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Models.Institutions.Commands.CreateInstitution
{
    public sealed class CreateInstitutionHandler
        : IRequestHandler<CreateInstitutionCommand, InstitutionResponseDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IInstitutionProvider _institutionProvider;

        public CreateInstitutionHandler(
            ApplicationDbContext context,
            IInstitutionProvider institutionProvider
        )
        {
            _context = context;
            _institutionProvider = institutionProvider;
        }

        public async Task<InstitutionResponseDto> Handle(
            CreateInstitutionCommand request,
            CancellationToken cancellationToken
        )
        {
            // Check if an institution with the same name already exists
            var existsByName = await _institutionProvider.ExistsByNameAsync(request.Name);

            if (existsByName)
            {
                throw new InvalidRequestException("Institution with the same name already exists.");
            }

            // Create the institution in database
            Institution institution = new() { Name = request.Name };

            await _context.Institutions.AddAsync(institution, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return institution.Adapt<InstitutionResponseDto>();
        }
    }
}
