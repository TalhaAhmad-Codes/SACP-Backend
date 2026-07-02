using Backend.Features.Academic.Commands.Institution.DeleteInstitution;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using MediatR;

namespace Backend.Features.Academic.Handlers.Institution.Command;

public sealed class DeleteInstitutionHandler : IRequestHandler<DeleteInstitutionCommand, bool>
{
    private readonly ApplicationDbContext _context;
    private readonly IInstitutionProvider _institutionProvider;

    public DeleteInstitutionHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider)
    {
        _context = context;
        _institutionProvider = institutionProvider;
    }

    public async Task<bool> Handle(DeleteInstitutionCommand request, CancellationToken cancellationToken)
    {
        var institution = await _institutionProvider.GetByIdAsync(request.Id, cancellationToken);

        if (institution is null)
            return false;

        _context.Institutions.Remove(institution);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}