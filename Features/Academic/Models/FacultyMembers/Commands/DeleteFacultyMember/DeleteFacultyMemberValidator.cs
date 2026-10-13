using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.FacultyMembers.Commands.DeleteFacultyMember
{
    public sealed class DeleteFacultyMemberValidator : AbstractValidator<DeleteFacultyMemberCommand>
    {
        public DeleteFacultyMemberValidator()
        {
            // Id
            RuleFor(f => f.Id).RequiredId();
        }
    }
}
