using Backend.Features.Academic.Models.Student.Enums;

namespace Backend.Features.Academic.Models.Student.Queries.GetStudent
{
    public sealed record StudentFilter(
        string? FirstName,
        string? LastName,
        string? FatherName,
        Gender? Gender,
        DateOnly? FromDateOfBirth,
        DateOnly? ToDateOfBirth,
        DateOnly? FromDateOfAdmission,
        DateOnly? ToDateOfAdmission,
        int? FromRollNumber,
        int? ToRollNumber,
        Guid? DepartmentId
    );
}
