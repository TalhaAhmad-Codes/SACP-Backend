using Backend.Features.Users.Responses;
using Backend.Shared.Common.Pagination;
using MediatR;

namespace Backend.Features.Users.Queries.GetUsers
{
    public sealed record GetUsersQuery(UserFilter Filter, int PageNumber = 1, int PageSize = 10)
        : IRequest<PagedResult<UserResponse>>;
}
