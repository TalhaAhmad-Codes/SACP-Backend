using Backend.Features.Academic.Models.Student.Commands.UpdateStudent;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Academic.Models.Student.Validators
{
    public sealed class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            // * Id
            RuleFor(s => s.Id).NotEmpty().WithMessage("Student must be provided");

            // * First Name
            RuleFor(s => s.FirstName)
                .NotEmpty()
                .WithMessage("Student's first name can't be empty")
                .MinimumLength(MinValue.PersonName)
                .WithMessage(
                    $"Student's first name must contain at least '{MinValue.PersonName}' characters"
                )
                .MaximumLength(MaxValue.PersonName)
                .WithMessage(
                    $"Student's first name can't contain more than '{MaxValue.PersonName}' characters"
                );

            // * Last Name
            RuleFor(s => s.LastName)
                .NotEmpty()
                .WithMessage("Student's last name can't be empty")
                .MinimumLength(MinValue.PersonName)
                .WithMessage(
                    $"Student's last name must contain at least '{MinValue.PersonName}' characters"
                )
                .MaximumLength(MaxValue.PersonName)
                .WithMessage(
                    $"Student's last name can't contain more than '{MaxValue.PersonName}' characters"
                );

            // * Father Name
            RuleFor(s => s.FatherName)
                .NotEmpty()
                .WithMessage("Student's father's name can't be empty")
                .MinimumLength(MinValue.PersonName)
                .WithMessage(
                    $"Student's father's name must contain at least '{MinValue.PersonName}' characters"
                )
                .MaximumLength(MaxValue.PersonFullName)
                .WithMessage(
                    $"Student's father's name can't contain more than '{MaxValue.PersonName}' characters"
                );

            // * Gender
            RuleFor(s => s.Gender).IsInEnum().WithMessage("Gender must be either male or female");

            // * Date of Birth
            RuleFor(s => s.DateOfBirth).LessThan(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Your current date can't be set as date of birth of the student");
        }
    }
}
