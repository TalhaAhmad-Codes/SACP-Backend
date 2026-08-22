using Backend.Features.Users.Commands.UpdateUser;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public class UpdateUserAvatarValidator : AbstractValidator<UpdateUserAvatarCommand>
    {
        public UpdateUserAvatarValidator()
        {
            RuleFor(a => a.UserId).NotEmpty().WithMessage("User id is required");

            RuleFor(a => a.Avatar).NotEmpty().WithMessage("Avatar file is required");
        }
    }
}
