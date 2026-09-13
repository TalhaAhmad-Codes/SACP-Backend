using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;

namespace Backend.Features.Users.Commands.UpdateUser.Username
{
    public sealed class UpdateUsernameValidator : BaseValidator<UpdateUsernameCommand>
    {
        public UpdateUsernameValidator()
            : base()
        {
            RuleFor(u => u.Username)
                .RequiredString("Username", MinValue.Username, MaxValue.Username);
        }
    }
}
