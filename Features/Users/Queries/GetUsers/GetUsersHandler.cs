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
            if (!string.IsNullOrWhiteSpace(request.Username))
                query = query.Where(u => EF.Functions.ILike(u.Username, $"{request.Username}%"));

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
