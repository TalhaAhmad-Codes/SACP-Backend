using Backend.Features.Academic.Models.ExamResult.Enums;

namespace Backend.Features.Academic.Models.ExamResult.Responses
{
    public record ExamResultResponse(
        Guid id,
        int ObtainedMarks,
        ExamResultStatus Status,
        Guid StudentId,
        Guid ExamId
    );
}
