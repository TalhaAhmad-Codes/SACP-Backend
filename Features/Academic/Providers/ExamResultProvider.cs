using Backend.Features.Academic.Models.ExamResult;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class ExamResultProvider : GeneralProvider<ExamResult>, IExamResultProvider
    {
        public ExamResultProvider(ApplicationDbContext context) : base(context) { }
    }
}
