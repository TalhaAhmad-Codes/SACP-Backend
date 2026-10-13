using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Admins.Commands.DeleteAdmin
{
    public sealed class DeleteAdminValidator : AbstractValidator<DeleteAdminCommand>
    {
        public DeleteAdminValidator()
        {
            RuleFor(a => a.Id).RequiredId();
        }
    }
}
