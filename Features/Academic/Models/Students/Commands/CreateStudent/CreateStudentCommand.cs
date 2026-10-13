using Backend.Features.Academic.Models.Students.Enums;
using Backend.Features.Academic.Models.Students.Responses;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Commands.CreateStudent
{
    public sealed class CreateStudentCommand : IRequest<StudentResponseDto>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string? RegistrationNumber { get; init; }
        public DateOnly EnrollmentDate { get; init; }
        public AcademicStatus AcademicStatus { get; init; }
        public int Semester { get; init; }

        public Guid? UserId { get; init; }
        public Guid DepartmentId { get; init; }
        public Guid DegreeId { get; init; }
    }
}
