using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Attendance : BaseEntity
    {
        public AttendanceType Type { get; set; }
        public AttendanceStatus Status { get; set; }
        public DateOnly DateOfMarking { get; set; }

        // * Foreign Keys
        public Guid CourseId { get; set; }
        public Guid FacultyId { get; set; }
        public Guid StudentId { get; set; }
    }
}
