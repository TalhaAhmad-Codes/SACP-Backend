using Backend.Features.Academic.Models.Student.Commands.CreateStudent;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Academic.Models.Student.Validators
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

            // * Roll Number
            RuleFor(s => s.RollNumber)
                .GreaterThan(0)
                .WithMessage("Roll number must be greater than 0");

            // * Email
            RuleFor(s => s.Email)
                .EmailAddress()
                .WithMessage("Email format is invalid");

            // * Registration Number
            RuleFor(s => s.RegistrationNumber)
                .NotEmpty()
                .WithMessage("Registration number must not be empty")
                .When(s => s.RegistrationNumber is not null);

            // * Department Id
            RuleFor(s => s.DepartmentId)
                .NotEmpty()
                .WithMessage("Department must be provided");
        }
    }
}
