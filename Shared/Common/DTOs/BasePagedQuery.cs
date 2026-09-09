namespace Backend.Shared.Common.DTOs
{
    public abstract class BasePagedQuery
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
