using Backend.Shared.Extensions;
using FluentValidation;

namespace Backend.Features.Academic.Models.Students.Queries.GetStudentById
{
    public sealed class GetStudentByIdValidator : AbstractValidator<GetStudentByIdQuery>
    {
        public GetStudentByIdValidator()
        {
            RuleFor(s => s.Id).RequiredId();
        }
    }
}
