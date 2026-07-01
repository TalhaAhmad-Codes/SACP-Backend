using Backend.Features.Academic.Queries.Student.GetStudent;
using FluentValidation;

namespace Backend.Features.Academic.Validators.Student;

public sealed class GetStudentByRegistrationNumberValidator : AbstractValidator<GetStudentByRegistrationNumberQuery>
{
    public GetStudentByRegistrationNumberValidator()
    {
        // * Registration Number
        RuleFor(s => s.RegistrationNumber)
            .NotEmpty().WithMessage("Registration number must be provided");
    }
}