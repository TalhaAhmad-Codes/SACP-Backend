using Backend.Features.Users.Commands.UpdateUser;
using Backend.Shared.Common;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public class UpdateUserAvatarValidator : BaseValidator<UpdateUserAvatarCommand>
    {
        public UpdateUserAvatarValidator()
            : base()
        {
            RuleFor(a => a.Avatar).NotEmpty().WithMessage(Message.NotEmpty("Avatar"));
        }
    }
}
