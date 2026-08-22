using Backend.Features.Academic.Models.Course;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class CourseProvider : GeneralProvider<Course>, ICourseProvider
    {
        public CourseProvider(ApplicationDbContext context) : base(context) { }
    }
}
