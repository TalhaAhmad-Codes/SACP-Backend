using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMemberById
{
    public sealed class GetFacultyMemberByIdValidator : AbstractValidator<GetFacultyMemberByIdQuery>
    {
        public GetFacultyMemberByIdValidator()
        {
            // Id
            RuleFor(f => f.Id).RequiredId();
        }
    }
}
