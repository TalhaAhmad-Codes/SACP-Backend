using Backend.Features.Users.Commands.UpdateUser;
using Backend.Shared.Common.FixedValue;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;

namespace Backend.Features.Users.Validators
{
    public sealed class UpdateUserUsernameValidator : BaseValidator<UpdateUsernameCommand>
    {
        public UpdateUserUsernameValidator()
            : base()
        {
            RuleFor(u => u.Username)
                .RequiredString("Username", MinValue.Username, MaxValue.Username);
        }
    }
}
