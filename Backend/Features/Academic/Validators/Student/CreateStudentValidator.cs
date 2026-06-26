using Backend.Features.Academic.Commands.Student.CreateStudent;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Academic.Validators.Student
{
    public sealed class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
            // * First Name
            RuleFor(s => s.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MinimumLength(MinValue.PersonName)
                .WithMessage(
                    $"The first name of student must contain least {MinValue.PersonName} characters"
                )
                .MaximumLength(MaxValue.PersonName)
                .WithMessage(
                    $"The first name of student can't contain more than {MaxValue.PersonName} characters"
                );

            // * Last Name
            RuleFor(s => s.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MinimumLength(MinValue.PersonName)
                .WithMessage(
                    $"The last name of student must contain least {MinValue.PersonName} characters"
                )
                .MaximumLength(MaxValue.PersonName)
                .WithMessage(
                    $"The last name of student can't contain more than {MaxValue.PersonName} characters"
                );

            // * Father Name
            RuleFor(s => s.FatherName)
                .NotEmpty()
                .WithMessage("Father name is required")
                .MinimumLength(MinValue.PersonName)
                .WithMessage(
                    $"The father name of student must contain least {MinValue.PersonName} characters"
                )
                .MaximumLength(MaxValue.PersonFullName)
                .WithMessage(
                    $"The father name of student can't contain more than {MaxValue.PersonFullName} characters"
                );

            // * Gender
            RuleFor(s => s.Gender)
                .IsInEnum()
                .WithMessage("The gender must be either male or female");

            // * Date of Birth
            RuleFor(s => s.DateOfBirth)
                .LessThan(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Date of Birth must be in past");

            // * Date of Admission
            RuleFor(s => s.DateOfAdmission)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Date of admission can't be in future");
        }
    }
}
