using Backend.Features.Academic.Models.Exam.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models.Exam
{
    public sealed class Exam : BaseEntity
    {
        public ExamType Type { get; set; }
        public DateOnly DateOfConduct { get; set; }
        public int TotalMarks { get; set; }

        // * Foreign Key Constraint
        public Guid CourseId { get; set; }
        public Course.Course Course { get; set; }

        // * Relation
        public ICollection<ExamResult.ExamResult> ExamResults { get; set; }
    }
}
