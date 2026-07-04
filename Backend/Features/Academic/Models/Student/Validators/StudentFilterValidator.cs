using Backend.Features.Academic.Models.Student.Queries.GetStudent;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Academic.Models.Student.Validators
{
    public sealed class StudentFilterValidator : AbstractValidator<StudentFilter>
    {
        public StudentFilterValidator()
        {
            // * First Name
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage($"Student first name must not be empty")
                .MinimumLength(MinValue.PersonName).WithMessage($"Student's first name must contain at least '{MinValue.PersonName}' characters")
                .MaximumLength(MaxValue.PersonName).WithMessage($"Student's first name must not exceed '{MaxValue.PersonName}' characters")
                .When(s => s.FirstName is not null);

            // * Last Name
            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage($"Student last name must not be empty")
                .MinimumLength(MinValue.PersonName).WithMessage($"Student's last name must contain at least '{MinValue.PersonName}' characters")
                .MaximumLength(MaxValue.PersonName).WithMessage($"Student's last name must not exceed '{MaxValue.PersonName}' characters")
                .When(s => s.LastName is not null);

            // * Father Name
            RuleFor(s => s.FatherName)
                .NotEmpty().WithMessage($"Student father name must not be empty")
                .MinimumLength(MinValue.PersonName).WithMessage($"Student's father name must contain at least '{MinValue.PersonName}' characters")
                .MaximumLength(MaxValue.PersonFullName).WithMessage($"Student's father name must not exceed '{MaxValue.PersonName}' characters")
                .When(s => s.FatherName is not null);

            // * Gender
            RuleFor(s => s.Gender)
                .IsInEnum().WithMessage("Gender must be either male or female")
                .When(s => s.Gender.HasValue);

            // * From date of birth
            RuleFor(s => s.FromDateOfBirth)
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth can't be current date")
                .When(s => s.FromDateOfBirth.HasValue);

            // * To date of birth
            RuleFor(s => s.ToDateOfBirth)
                .LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of birth can't be current date")
                .When(s => s.ToDateOfBirth.HasValue);

            RuleFor(s => s.ToDateOfBirth)
                .GreaterThan(s => s.FromDateOfBirth).WithMessage("The range of date of birth must be exclusive")
                .When(s => s.FromDateOfBirth.HasValue && s.ToDateOfBirth.HasValue);

            // * From date of admission
            RuleFor(s => s.FromDateOfAdmission)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of admission can't be in future")
                .When(s => s.FromDateOfAdmission.HasValue);

            // * To date of admission
            RuleFor(s => s.ToDateOfAdmission)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Date of admission can't be in future")
                .When(s => s.ToDateOfAdmission.HasValue);

            RuleFor(s => s.ToDateOfAdmission)
                .GreaterThan(s => s.FromDateOfBirth).WithMessage("The range date of admission must be exclusive")
                .When(s => s.FromDateOfAdmission.HasValue && s.ToDateOfAdmission.HasValue);

            // * From Roll Number
            RuleFor(s => s.FromRollNumber)
                .GreaterThan(0).WithMessage("Roll number must be greater than 0")
                .When(s => s.FromRollNumber.HasValue);

            // * From Roll Number
            RuleFor(s => s.ToRollNumber)
                .GreaterThan(0).WithMessage("Roll number must be greater than 0")
                .When(s => s.ToRollNumber.HasValue);

            RuleFor(s => s.ToRollNumber)
                .GreaterThan(s => s.FromRollNumber).WithMessage("The range of roll number must be exclusive")
                .When(s => s.FromRollNumber.HasValue && s.ToRollNumber.HasValue);
        }
    }
}
