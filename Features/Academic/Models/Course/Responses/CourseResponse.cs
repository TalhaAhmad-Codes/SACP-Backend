using Backend.Features.Academic.Models.Course.Enums;

namespace Backend.Features.Academic.Models.Course.Responses
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
