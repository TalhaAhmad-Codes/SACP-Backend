using Backend.Shared.Common;
using Backend.Shared.Common.FixedValue;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Users.Queries.GetUsers
{
    public sealed class GetUsersValidator : BasePagedValidator<GetUsersQuery>
    {
        public GetUsersValidator()
            : base()
        {
            RuleFor(u => u.Username)
                .StringMinMax("Username", 1, MaxValue.Username)
                .Unless(u => string.IsNullOrEmpty(u.Username));

            RuleFor(u => u.Role).IsInEnum().WithMessage(Message.InvalidEnum("Role"));
        }
    }
}
