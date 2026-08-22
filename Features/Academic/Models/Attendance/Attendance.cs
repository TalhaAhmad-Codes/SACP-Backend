using Backend.Features.Academic.Models.Attendance.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Attendance
{
    public sealed class Attendance : BaseEntity
    {
        public AttendanceType Type { get; set; }
        public AttendanceStatus Status { get; set; }
        public DateOnly DateOfMarking { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        // * Foreign Key Constraints
        public Guid CourseId { get; set; }
        public Course.Course Course { get; set; }

        public Guid FacultyId { get; set; }
        public FacultyMember.FacultyMember FacultyMember { get; set; }

        public Guid StudentId { get; set; }
        public Student.Student Student { get; set; }
    }
}
