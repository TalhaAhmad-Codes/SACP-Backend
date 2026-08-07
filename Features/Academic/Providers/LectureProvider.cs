using Backend.Features.Academic.Models.CourseAssignment;
using Backend.Features.Academic.Models.CourseEnrollment;
using Backend.Features.Academic.Providers.Interfaces;
using Backend.Features.Academic.Models.FacultyMember;
using Backend.Features.Academic.Models.Lecture;
using Backend.Features.Academic.Models.Student;
using Backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Backend.Shared.Exceptions;
using Backend.Shared.Providers;

namespace Backend.Features.Academic.Providers
{
    public sealed class LectureProvider : GeneralProvider<Lecture>, ILectureProvider
    {
        public LectureProvider(ApplicationDbContext context) : base(context) { }

        public async Task<CourseAssignment> GetCourseAssignmentByCourseIdAsync(Guid courseId)
        {
            var courseAssignment = await _context.CourseAssignments.FirstOrDefaultAsync(ca => ca.CourseId == courseId) ?? throw new NotExistsException("Crouse assignment doesn't exist with given course id");

            return courseAssignment;
        }

        public async Task<List<CourseEnrollment>> GetCourseEnrollmentsByCourseIdAsync(Guid courseId)
            => await _context.CourseEnrollments
                .Where(ce => ce.CourseId == courseId)
                .AsNoTracking()
                .ToListAsync();

        public async Task<FacultyMember> GetFacultyMemberByCourseIdAsync(Guid courseId)
        {
            var courseAssignment = await GetCourseAssignmentByCourseIdAsync(courseId);

            var faculty = await _context.FacultyMembers.FirstOrDefaultAsync(f => f.Id == courseAssignment.FacultyId) ?? throw new NotExistsException("Faculty member doesn't exist with given course id");

            return faculty;
        }

        public async Task<List<Student>> GetStudentsByCourseIdAsync(Guid courseId)
            => await _context.Students
                .Where(s => s.CourseEnrollments.Any(ce => ce.CourseId == courseId))
                .AsNoTracking()
                .ToListAsync();
    }
}
