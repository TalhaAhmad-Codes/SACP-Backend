using Backend.Features.Academic.Models.Sessions.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Academic.Models.Sessions.Queries.GetSessions
{
    public sealed class GetSessionsHandler
        : IRequestHandler<GetSessionsQuery, PagedResultDto<SessionResponseDto>>
    {
        private readonly ApplicationDbContext _context;

        public GetSessionsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<SessionResponseDto>> Handle(
            GetSessionsQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.Sessions.AsNoTracking();

            // Filteration
            if (request.Name is not null)
                query = query.Where(s => EF.Functions.ILike(s.Name, $"{request.Name}%"));

            if (request.FromDate.HasValue)
                query = query.Where(s => s.StartDate >= request.FromDate);

            if (request.ToDate.HasValue)
                query = query.Where(s => s.StartDate <= request.FromDate);

            if (request.IsExpired.HasValue)
                query = query.Where(s => s.IsExpired == request.IsExpired);

            var result = await query
                .OrderByDescending(s => s.StartDate)
                .ProjectToType<SessionResponseDto>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return result;
        }
    }
}
