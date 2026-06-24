using Backend.Features.Academic.Models;
using Backend.Features.Academic.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            // * Attendance Type
            builder
                .Property(a => a.Type)
                .HasColumnName("Type")
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(AttendanceType.Regular);

            // * Attendance Status
            builder
                .Property(a => a.Status)
                .HasColumnName("Status")
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(AttendanceStatus.Present);

            // * Date of Marking
            builder.Property(a => a.DateOfMarking).IsRequired();

            // * Course - Relationship
            builder
                .HasOne(a => a.Course)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Faculty Member - Relationship
            builder
                .HasOne(a => a.FacultyMember)
                .WithMany(fm => fm.Attendances)
                .HasForeignKey(a => a.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Student - Relationship
            builder
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
