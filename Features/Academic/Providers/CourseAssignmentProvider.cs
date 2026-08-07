using Backend.Features.Academic.Models.CourseAssignment;
using Backend.Infrastructure.Persistence;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class CourseAssignmentProvider : GeneralProvider<CourseAssignment>
    {
        public CourseAssignmentProvider(ApplicationDbContext context) : base(context) { }
    }
}
