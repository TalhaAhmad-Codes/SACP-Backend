using Backend.Features.Users.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.DTOs;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Users.Queries.GetUsers
{
    public sealed class GetUsersHandler
        : IRequestHandler<GetUsersQuery, PagedResultDto<UserResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResultDto<UserResponse>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.Users.AsNoTracking();

            // Applying filters
            if (request.Username is not null)
                query = query.Where(u =>
                    u.Username.StartsWith(request.Username, StringComparison.OrdinalIgnoreCase)
                );

            if (request.Role.HasValue)
                query = query.Where(u => u.Role == request.Role);

            if (request.IsActive.HasValue)
                query = query.Where(u => u.IsActive == request.IsActive);

            // Paging
            var users = await query
                .OrderBy(u => u.Username)
                .ProjectToType<UserResponse>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return users;
        }
    }
}
