using Backend.Features.Academic.Commands.Institution.UpdateInstitution;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Features.Academic.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Exceptions;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Handlers.Institution.Command;

public sealed class UpdateInstitutionHandler : IRequestHandler<UpdateInstitutionCommand, InstitutionResponse>
{
    private readonly ApplicationDbContext _context;
    private readonly IInstitutionProvider _institutionProvider;

    public UpdateInstitutionHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider)
    {
        _context = context;
        _institutionProvider = institutionProvider;
    }

    public async Task<InstitutionResponse> Handle(UpdateInstitutionCommand request, CancellationToken cancellationToken)
    {
        var institution = await _institutionProvider.GetByIdAsync(request.Id, cancellationToken);

        if (institution is null)
            throw new DomainException("Institution doesn't exist");

        var existsByName = await _institutionProvider.ExistsByNameAsync(request.Name.Trim(), cancellationToken);

        if (existsByName)
            throw new DomainException("Institution already exists with given name");

        institution.Name = request.Name.Trim();
        _context.Institutions.Update(institution);
        await _context.SaveChangesAsync(cancellationToken);

        return institution.Adapt<InstitutionResponse>();
    }
}
