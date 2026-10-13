using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Admins.Queries.GetAdminById
{
    public sealed class GetAdminByIdValidator : AbstractValidator<GetAdminByIdQuery>
    {
        public GetAdminByIdValidator()
        {
            RuleFor(a => a.Id).RequiredId();
        }
    }
}
