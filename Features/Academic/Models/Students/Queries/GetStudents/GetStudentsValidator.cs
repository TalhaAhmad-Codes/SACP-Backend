using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentAssertions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Students.Queries.GetStudents
{
    public sealed class GetStudentsValidator : BasePagedValidator<GetStudentsQuery>
    {
        public GetStudentsValidator()
            : base()
        {
            // Name
            RuleFor(s => s.Name)
                .StringMinMax("Name", MinValue.PersonName, MaxValue.PersonFullName);

            // Registration Number
            RuleFor(s => s.RegistrationNumber)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Registration number"))
                .When(s => s.RegistrationNumber is not null);

            // Enrollment Date
            this.NullableDateRange(
                s => s.FromEnrollmentDate,
                s => s.ToEnrollmentDate,
                "Enrollment Date"
            );

            // Academic Status
            RuleFor(s => s.AcademicStatus!.Value).InEnum().When(s => s.AcademicStatus.HasValue);

            // Semester
            RuleFor(s => s.Semester)
                .GreaterThan(0)
                .WithMessage(Message.ZeroOrLess("Semester"))
                .When(s => s.Semester.HasValue);

            // Degree Id
            RuleFor(s => s.DegreeId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Degree"))
                .When(s => s.DegreeId.HasValue);

            // Department Id
            RuleFor(s => s.DepartmentId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Department"))
                .When(s => s.DepartmentId.HasValue);
        }
    }
}
