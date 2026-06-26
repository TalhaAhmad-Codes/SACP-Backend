using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Responses
{
    public record CourseResponse(
        Guid Id,
        string Title,
        string Code,
        int CreditHourse,
        Semester Semester,
        Guid DepartmentId
    );
}
