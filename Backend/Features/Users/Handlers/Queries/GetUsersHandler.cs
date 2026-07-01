using Backend.Features.Users.Queries.GetUsers;
using Backend.Features.Users.Responses;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Common.Pagination;
using Backend.Shared.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Features.Users.Handlers.Queries
{
    public sealed class GetUsersHandler : IRequestHandler<GetUsersQuery, PagedResult<UserResponse>>
    {
        private readonly ApplicationDbContext _context;

        public GetUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<UserResponse>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            var query = _context.Users.AsNoTracking().AsQueryable();

            // * Applying filters
            if (request.Filter.SearchUsername is not null)
                query = query.Where(u => u.Username.StartsWith(request.Filter.SearchUsername));

            if (request.Filter.Role.HasValue)
                query = query.Where(u => u.Role == request.Filter.Role);

            if (request.Filter.IsActive.HasValue)
                query = query.Where(u => u.IsActive == request.Filter.IsActive);

            // * Paging
            var users = await query
                .OrderBy(u => u.Username)
                .ProjectToType<UserResponse>()
                .ToPagedResultAsync(request.PageNumber, request.PageSize, cancellationToken);

            return users;
        }
    }
}
