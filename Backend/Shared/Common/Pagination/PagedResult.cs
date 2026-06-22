namespace Backend.Shared.Common.Pagination
{
    public sealed record PagedResult<T>(
        IReadOnlyCollection<T> Items,
        int TotalCount
    // int PageNumber,
    // int PageSize
    );
}
