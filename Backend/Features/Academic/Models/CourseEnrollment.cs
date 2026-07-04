using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class CourseEnrollment : BaseEntity
    {
        public CourseEnrollmentStatus Status { get; set; }

        // * Foreign Keys
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
