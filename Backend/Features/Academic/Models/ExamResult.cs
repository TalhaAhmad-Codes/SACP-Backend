using Backend.Features.Academic.Models.Enums;
using Backend.Shared.Common;

namespace Backend.Features.Academic.Models
{
    public sealed class ExamResult : BaseEntity
    {
        public int ObtainedMarks { get; set; }
        public ExamResultStatus Status { get; set; }

        // * Foreign Key Constraints
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
