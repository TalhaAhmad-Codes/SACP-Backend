using Backend.Features.Academic.Models.Course;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // * Title
            builder.Property(c => c.Title).HasMaxLength(MaxValue.CourseTitle).IsRequired();

            // * Code
            builder.Property(c => c.Code).HasMaxLength(MaxValue.CourseCode).IsRequired();

            // * Credit Hours
            builder.Property(c => c.CreditHours).IsRequired();

            // * Semester
            builder.Property(c => c.Semester).HasConversion<string>().IsRequired();

            // * Department - Relationship
            builder
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Course Assignment - Relationship
            builder.HasOne(c => c.CourseAssignment).WithOne(ca => ca.Course);

            // * Course Enrollment - Relationship
            builder.HasMany(c => c.CourseEnrollments).WithOne(ce => ce.Course);

            // * Attendance - Relationship
            builder.HasMany(c => c.Attendances).WithOne(a => a.Course);

            // * Exam - Relationship
            builder.HasMany(c => c.Exams).WithOne(e => e.Course);
        }
    }
}
