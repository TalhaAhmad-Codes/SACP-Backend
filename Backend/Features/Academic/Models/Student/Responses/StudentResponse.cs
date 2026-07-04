using Backend.Features.Academic.Models.Student.Enums;

namespace Backend.Features.Academic.Models.Student.Responses
{
    public record StudentResponse(
        Guid id,
        string Name,
        string FatherName,
        Gender Gender,
        DateOnly DateOfBirth,
        DateOnly DateOfAdmission,
        int RollNumber,
        string Email,
        string RegistrationNumber,
        Guid UserId,
        Guid DepartmentId
    );
}
