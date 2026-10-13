using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.CreateFacultyMember
{
    public sealed class CreateFacultyMemberValidator : AbstractValidator<CreateFacultyMemberCommand>
    {
        public CreateFacultyMemberValidator()
        {
            // Name
            RuleFor(f => f.FirstName)
                .RequiredString("First name", MinValue.PersonName, MaxValue.PersonName);

            RuleFor(f => f.LastName)
                .RequiredString("Last name", MinValue.PersonName, MaxValue.PersonName);

            // Role
            RuleFor(f => f.Role).InEnum();

            // DoJ
            RuleFor(f => f.DateOfJoining).PastOrPresentDate("Date of Joining");

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
