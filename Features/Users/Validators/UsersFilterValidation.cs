using System.Data;
using Backend.Features.Users.Queries.GetUsers;
using Backend.Shared.Common.FixedValue;
using FluentValidation;

namespace Backend.Features.Users.Validators
{
    public sealed class UsersFilterValidation : AbstractValidator<UserFilter>
    {
        public UsersFilterValidation()
        {
            RuleFor(u => u.SearchUsername)
                .NotEmpty()
                .WithMessage("You must write something for search by name")
                .MinimumLength(1)
                .WithMessage($"You must write at least 1 character")
                .MaximumLength(MaxValue.Username)
                .WithMessage($"You must not exceed '{MaxValue.Username}' characters")
                .When(u => u.SearchUsername is not null);

            RuleFor(u => u.Role).IsInEnum().When(u => u.Role.HasValue);

            RuleFor(u => u.IsActive).IsInEnum().When(u => u.IsActive.HasValue);
        }
    }
}
