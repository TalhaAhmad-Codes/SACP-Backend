using Backend.Features.Users.Queries.GetUsers;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class GetUsersValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersValidator()
        {
            RuleFor(u => u.PageNumber)
                .GreaterThanOrEqualTo(MinValue.PageNumber)
                .WithMessage($"Page number must be {MinValue.PageNumber} or greater");

            RuleFor(u => u.PageSize)
                .GreaterThanOrEqualTo(MinValue.PageSize)
                .WithMessage($"Page size must be {MinValue.PageSize} or greater");
        }
    }
}
