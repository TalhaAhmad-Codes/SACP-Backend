using Backend.Features.Academic.Models.Enums;

namespace Backend.Features.Academic.Responses
{
    public record ExamResultResponse(
        Guid id,
        int ObtainedMarks,
        ExamResultStatus Status,
        Guid StudentId,
        Guid ExamId
    );
}
