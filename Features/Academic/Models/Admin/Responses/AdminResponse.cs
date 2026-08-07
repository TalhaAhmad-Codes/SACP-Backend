namespace Backend.Features.Academic.Models.Admin.Responses
{
    public record AdminResponse(
        Guid Id,
        string Name,
        Guid UserId,
        Guid InstitutionId,
        DateTime CreatedAt
    );
}
