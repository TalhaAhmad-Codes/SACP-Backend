using Backend.Features.Academic.Models.Institutions.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Institutions.Queries.GetInstitutions
{
    public sealed class GetInstitutionsHandler
        : IRequestHandler<GetInstitutionsQuery, PagedResultDto<InstitutionResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetInstitutionsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<InstitutionResponseDto>> Handle(
            GetInstitutionsQuery request,
            CancellationToken cancellationToken
        )
        {
            // Get institutions' query
            var query = _context.Institutions.AsNoTracking();

            // Applying filters
            if (request.Name is not null)
                query = query.Where(i => EF.Functions.ILike(request.Name, $"{request.Name}%"));

            // Paging
            var institutions = await query
                .OrderBy(i => i.Name)
                .ProjectToType<InstitutionResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return institutions;
        }
    }
}
