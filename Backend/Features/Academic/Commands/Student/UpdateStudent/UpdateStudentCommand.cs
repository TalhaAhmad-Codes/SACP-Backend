using Backend.Features.Academic.Models.Enums;
using MediatR;

namespace Backend.Features.Academic.Commands.Student.UpdateStudent
{
    public record UpdateStudentCommand(
        Guid Id,
        string FirstName,
        string LastName,
        string FatherName,
        Gender Gender,
        DateOnly DateOfBirth,
        DateOnly DateOfAdmission,
        int RollNumber,
        string Email,
        Guid DepartmentId
    ) : IRequest<bool>;
}
