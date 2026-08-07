using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Lecture
{
    public sealed class Lecture : BaseEntity
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        // * Foreign Key
        public Guid CourseId { get; set; }
        public Course.Course Course { get; set; }
    }
}
