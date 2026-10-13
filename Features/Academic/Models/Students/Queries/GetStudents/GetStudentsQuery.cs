using Backend.Features.Academic.Models.Students.Enums;
using Backend.Features.Academic.Models.Students.Responses;
using Backend.Shared.Common.DTOs;
using MediatR;

namespace Backend.Features.Academic.Models.Students.Queries.GetStudents
{
    public sealed class GetStudentsQuery
        : BasePagedQuery,
            IRequest<PagedResultDto<StudentResponseDto>>
    {
        public string? Name { get; init; }
        public string? RegistrationNumber { get; init; }
        public DateOnly? FromEnrollmentDate { get; init; }
        public DateOnly? ToEnrollmentDate { get; init; }
        public AcademicStatus? AcademicStatus { get; init; }
        public int? Semester { get; init; }
        public bool? IsActive { get; init; }

        public Guid? DepartmentId { get; init; }
        public Guid? DegreeId { get; init; }
    }
}
