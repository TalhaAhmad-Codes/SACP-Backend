using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.UpdateFacultyMember
{
    public sealed class UpdateFacultyMemberValidator : AbstractValidator<UpdateFacultyMemberCommand>
    {
        public UpdateFacultyMemberValidator()
        {
            // Id
            RuleFor(f => f.Id).RequiredId();

            // Name
            RuleFor(f => f.FirstName)
                .RequiredString("First name", MinValue.PersonName, MaxValue.PersonName);

            RuleFor(f => f.LastName)
                .RequiredString("Last name", MinValue.PersonName, MaxValue.PersonName);

            // Role
            RuleFor(f => f.Role).InEnum();

            // DoJ
            RuleFor(f => f.DateOfJoining)
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
                .WithMessage(Message.MustPastOrPresentDate("Date of joining"));

            // User Id
            RuleFor(f => f.UserId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("User"))
                .When(f => f.UserId.HasValue);

            // Department Id
            RuleFor(f => f.DepartmentId).RequiredId("Department");
        }
    }
}
