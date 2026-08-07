namespace Backend.Shared.Common.Pagination
{
    public record PageRequest(int PageNumber = 1, int PageSize = 10);
}
