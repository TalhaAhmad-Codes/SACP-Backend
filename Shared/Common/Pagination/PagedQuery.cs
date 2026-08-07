using MediatR;

namespace Backend.Shared.Common.Pagination
{
    public abstract record PagedQuery<TResponse>(int PageNumber = 1, int PageSize = 10)
        : IRequest<PagedResult<TResponse>>;
}
