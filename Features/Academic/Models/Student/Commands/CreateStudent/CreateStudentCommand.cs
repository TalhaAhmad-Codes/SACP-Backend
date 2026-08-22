using Backend.Features.Academic.Models.Student.Enums;
using MediatR;

namespace Backend.Features.Academic.Models.Student.Commands.CreateStudent
{
    public record CreateStudentCommand(
        string FirstName,
        string LastName,
        string FatherName,
        Gender Gender,
        DateOnly DateOfBirth,
        DateOnly DateOfAdmission,
        int RollNumber,
        string Email,
        string? RegistrationNumber,
        Guid DepartmentId
    ) : IRequest<Guid>;
}
