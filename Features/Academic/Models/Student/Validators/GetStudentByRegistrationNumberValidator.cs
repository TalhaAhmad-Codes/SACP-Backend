using Backend.Features.Academic.Models.Student.Queries.GetStudent;
using FluentValidation;

namespace Backend.Features.Academic.Models.Student.Validators
{
    public sealed class GetStudentByRegistrationNumberValidator : AbstractValidator<GetStudentByRegistrationNumberQuery>
    {
        public GetStudentByRegistrationNumberValidator()
        {
            // * Registration Number
            RuleFor(s => s.RegistrationNumber)
                .NotEmpty().WithMessage("Registration number must be provided");
        }
    }
}
