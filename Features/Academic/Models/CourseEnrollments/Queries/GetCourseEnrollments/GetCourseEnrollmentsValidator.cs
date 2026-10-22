using Backend.Shared.Common.Utilities;
using Backend.Shared.Extensions;
using Backend.Shared.Validators;
using FluentValidation;

namespace Backend.Features.Academic.Models.CourseEnrollments.Queries.GetCourseEnrollments
{
    public sealed class GetCourseEnrollmentsValidator
        : BasePagedValidator<GetCourseEnrollmentsQuery>
    {
        public GetCourseEnrollmentsValidator()
            : base()
        {
            RuleFor(e => e.Status!.Value).InEnum().When(e => e.Status.HasValue);

            RuleFor(e => e.CourseId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Course"))
                .When(e => e.CourseId.HasValue);

            RuleFor(e => e.SessionId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Session"))
                .When(e => e.SessionId.HasValue);

            RuleFor(e => e.StudentId)
                .NotEmpty()
                .WithMessage(Message.NotEmpty("Student"))
                .When(e => e.StudentId.HasValue);
        }
    }
}
