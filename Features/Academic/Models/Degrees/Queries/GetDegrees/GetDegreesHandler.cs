using Backend.Features.Academic.Models.Degrees.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Degrees.Queries.GetDegrees
{
    public sealed class GetDegreesHandler
        : IRequestHandler<GetDegreesQuery, PagedResultDto<DegreeResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetDegreesHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<DegreeResponseDto>> Handle(
            GetDegreesQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.Degrees.AsNoTracking();

            // Filteration
            if (request.Title is not null)
                query = query.Where(d => EF.Functions.ILike(d.Title, $"{request.Title}%"));

            if (request.Code is not null)
                query = query.Where(d => EF.Functions.ILike(d.Code, $"{request.Code}%"));

            if (request.DepartmentId.HasValue)
                query = query.Where(d => d.DepartmentId == request.DepartmentId);

            var result = await query
                .OrderBy(d => d.Title)
                .ProjectToType<DegreeResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}
