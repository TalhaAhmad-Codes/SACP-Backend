using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.FacultyMembers.Queries.GetFacultyMembers
{
    public sealed class GetFacultyMembersValidator : BasePagedValidator<GetFacultyMembersQuery>
    {
        public GetFacultyMembersValidator()
            : base()
        {
            // Name
            RuleFor(f => f.Name)
                .StringMinMax("Name", MinValue.PersonName, MaxValue.PersonFullName);

            // Role
            RuleFor(f => f.Role!.Value).InEnum().When(f => f.Role.HasValue);

            // Date of Joining
            this.NullableDateRange(
                f => f.FromDateOfJoining,
                f => f.ToDateOfJoining,
                "Date of Joining"
            );

            // Department Id
            RuleFor(f => f.DepartmentId!.Value)
                .RequiredId("Department")
                .When(f => f.DepartmentId.HasValue);
        }
    }
}
