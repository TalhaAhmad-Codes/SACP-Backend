using Backend.Features.Academic.Models.Exam.Enums;

namespace Backend.Features.Academic.Models.Exam.Responses
{
    public record ExamResponse(
        Guid id,
        ExamType Type,
        DateOnly DateOfConduct,
        int TotalMarks,
        Guid CourseId
    );
}
