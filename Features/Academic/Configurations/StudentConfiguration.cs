using Backend.Features.Academic.Models.Student;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // * Name
            builder.OwnsOne(
                s => s.Name,
                name =>
                {
                    name.Property(n => n.FirstName).HasMaxLength(MaxValue.PersonName).IsRequired();
                    name.Property(n => n.LastName).HasMaxLength(MaxValue.PersonName).IsRequired();
                }
            );

            // * Father Name
            builder.Property(s => s.FatherName).HasMaxLength(MaxValue.PersonFullName).IsRequired();

            // * Gender
            builder.Property(s => s.Gender).HasConversion<string>().IsRequired();

            // * Date of Birth
            builder.Property(s => s.DateOfBirth).IsRequired();

            // * Date of Admission
            builder.Property(s => s.DateOfAdmission).IsRequired();

            // * Roll Number
            builder.Property(s => s.RollNumber).IsRequired();
            builder.HasIndex(s => new { s.RollNumber, s.YearOfAdmission }).IsUnique(); // ? Unique roll number based on the year of admission

            // * Email
            builder.Property(s => s.Email).IsRequired();
            builder.HasIndex(s => s.Email).IsUnique();

            // * Registration Number
            builder.Property(s => s.RegistrationNumber).IsRequired();
            builder.HasIndex(s => s.RegistrationNumber).IsUnique();

            // * User - Relationship
            builder
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Department - Relationship
            builder
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Course Enrollment - Relationship
            builder.HasMany(s => s.CourseEnrollments).WithOne(ce => ce.Student);

            // * Attendance - Relationship
            builder.HasMany(s => s.Attendances).WithOne(a => a.Student);

            // * Exam Result - Relationship
            builder.HasMany(s => s.ExamResults).WithOne(er => er.Student);

            // * Ignored attributes
            builder.Ignore(s => s.Age);
            builder.Ignore(s => s.YearOfAdmission);
        }
    }
}
