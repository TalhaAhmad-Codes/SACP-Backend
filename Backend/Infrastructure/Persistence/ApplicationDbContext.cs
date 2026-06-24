using Backend.Features.Academic.Models;
using Backend.Features.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        // ? Auth
        public DbSet<User> Users => Set<User>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        // ? Academic
        public DbSet<Institution> Institutions => Set<Institution>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<FacultyMember> FacultyMembers => Set<FacultyMember>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<CourseEnrollment> CourseEnrollments => Set<CourseEnrollment>();
        public DbSet<CourseAssignment> CourseAssignments => Set<CourseAssignment>();
        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<Exam> Exams => Set<Exam>();
        public DbSet<ExamResult> ExamResults => Set<ExamResult>();
    }
}
