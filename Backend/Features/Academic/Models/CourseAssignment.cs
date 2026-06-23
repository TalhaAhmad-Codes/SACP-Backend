using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class CourseAssignment : BaseEntity
    {
        public CourseAssignmentStatus Status { get; set; }

        // * Foreign Keys
        public Guid CourseId { get; set; }
        public Guid FacultyId { get; set; }
    }
}
