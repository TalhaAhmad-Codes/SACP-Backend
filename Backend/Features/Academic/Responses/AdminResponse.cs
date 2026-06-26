namespace Backend.Features.Academic.Responses
{
    public record AdminResponse(
        Guid Id,
        string Name,
        Guid UserId,
        Guid InstitutionId,
        DateTime CreatedAt
    );
}
