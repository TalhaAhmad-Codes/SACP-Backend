using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class Exam : BaseEntity
    {
        public ExamType Type { get; set; }
        public DateOnly DateOfConduct { get; set; }
        public int TotalMarks { get; set; }

        // * Foreign Key Constraint
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        // * Relation
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}
