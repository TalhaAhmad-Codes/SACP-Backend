using Backend.Shared.Common;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Users.Commands.UpdateUser.Avatar
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
