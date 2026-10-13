using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Sessions.Commands.DeleteSession
{
    public sealed class DeleteSessionValidator : AbstractValidator<DeleteSessionCommand>
    {
        public DeleteSessionValidator()
        {
            RuleFor(s => s.Id).RequiredId();
        }
    }
}
