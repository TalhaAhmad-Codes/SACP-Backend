using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Students.Commands.UpdateStudent
{
    public sealed class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            // Id
            RuleFor(s => s.Id).RequiredId();

            // Name
            RuleFor(s => s.FirstName)
                .RequiredString("First name", MinValue.PersonName, MaxValue.PersonName);

            RuleFor(s => s.LastName)
                .RequiredString("Last name", MinValue.PersonName, MaxValue.PersonName);

            // Registration Number
            RuleFor(s => s.RegistrationNumber)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Registration number"))
                .When(s => s.RegistrationNumber is not null);

            // Enrollment Date
            RuleFor(s => s.EnrollmentDate).PastOrPresentDate("Enrollment Date");

            // Academic Status
            RuleFor(s => s.AcademicStatus).InEnum();

            // Semester
            RuleFor(s => s.Semester).GreaterThan(0).WithMessage(Message.ZeroOrLess("Semester"));

            // User Id
            RuleFor(s => s.UserId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("User"))
                .When(s => s.UserId.HasValue);

            // Degree Id
            RuleFor(s => s.DegreeId).RequiredId("Degree");

            // Department Id
            RuleFor(s => s.DepartmentId).RequiredId("Department");
        }
    }
}
