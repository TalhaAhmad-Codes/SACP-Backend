using Backend.Features.Academic.Models.Exam;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class ExamProvider : GeneralProvider<Exam>, IExamProvider
    {
        public ExamProvider(ApplicationDbContext context) : base(context) { }
    }
}
