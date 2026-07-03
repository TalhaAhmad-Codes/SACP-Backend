using Backend.Features.Academic.Providers.Interfaces;
using Backend.Features.Academic.Queries.Institution.GetInstitution;
using Backend.Features.Academic.Responses;
using Backend.Infrastructure.Persistence;
using Mapster;
using MediatR;

namespace Backend.Features.Academic.Handlers.Institution.Queries;

public sealed class GetInstitutionByIdHandler : IRequestHandler<GetInstitutionByIdQuery, InstitutionResponse>
{
    // private readonly ApplicationDbContext _context;
    private readonly IInstitutionProvider _institutionProvider;

    public GetInstitutionByIdHandler(ApplicationDbContext context, IInstitutionProvider institutionProvider)
    {
        // _context = context;
        _institutionProvider = institutionProvider;
    }

    public async Task<InstitutionResponse>
        Handle(GetInstitutionByIdQuery request, CancellationToken cancellationToken)
    {
        var institution = await _institutionProvider.GetByIdAsync(request.Id, cancellationToken);
        return institution.Adapt<InstitutionResponse>();
    }
}
