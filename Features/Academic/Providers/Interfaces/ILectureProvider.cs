using Backend.Features.Academic.Models.CourseAssignment;
using Backend.Features.Academic.Models.CourseEnrollment;
using Backend.Features.Academic.Models.FacultyMember;
using Backend.Features.Academic.Models.Lecture;
using Backend.Features.Academic.Models.Student;
using Backend.Shared.Providers.Interfaces;

namespace Backend.Features.Academic.Providers.Interfaces
{
    public interface ILectureProvider : IGeneralProvider<Lecture>
    {
        Task<List<Student>> GetStudentsByCourseIdAsync(Guid courseId);
        Task<FacultyMember> GetFacultyMemberByCourseIdAsync(Guid courseId);
        Task<List<CourseEnrollment>> GetCourseEnrollmentsByCourseIdAsync(Guid courseId);
        Task<CourseAssignment> GetCourseAssignmentByCourseIdAsync(Guid courseId);
    }
}
