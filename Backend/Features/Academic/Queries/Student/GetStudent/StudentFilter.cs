using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Queries.Student.GetStudent
{
    public sealed record StudentFilter(
        string? FirstName,
        string? LastName,
        string? FatherName,
        Gender? Gender,
        DateOnly? FromDateOfBirth,
        DateOnly? ToDateOfBirth,
        int? FromAge,
        int? ToAge,
        DateOnly? FromDateOfAdmission,
        DateOnly? ToDateOfAdmission,
        int? FromYearOfAdmission,
        int? ToYearOfAdmission,
        int? RollNumber,
        Guid? DepartmentId
    );
}
