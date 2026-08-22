using Backend.Features.Academic.Models.FacultyMember;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class FacultyMemberConfiguration : IEntityTypeConfiguration<FacultyMember>
    {
        public void Configure(EntityTypeBuilder<FacultyMember> builder)
        {
            // * Name
            builder.OwnsOne(
                fm => fm.Name,
                name =>
                {
                    name.Property(n => n.FirstName)
                        .HasColumnName("FirstName")
                        .HasMaxLength(MaxValue.PersonName)
                        .IsRequired();

                    name.Property(n => n.LastName)
                        .HasColumnName("LastName")
                        .HasMaxLength(MaxValue.PersonName)
                        .IsRequired();
                }
            );

            // * Job Role
            builder.Property(fm => fm.JobRole).HasConversion<string>().IsRequired();

            // * Date of Joining
            builder.Property(fm => fm.DateOfJoining).IsRequired();

            // * Status
            builder.Property(fm => fm.Status).HasConversion<string>().IsRequired();

            // * Access Code
            builder.Property(fm => fm.AccessCode).IsRequired();
            builder.HasIndex(fm => fm.AccessCode).IsUnique();

            // * Email
            builder.Property(fm => fm.Email).IsRequired();
            builder.HasIndex(fm => fm.Email).IsUnique();

            // * User - Relationship
            builder
                .HasOne(fm => fm.User)
                .WithOne(u => u.FacultyMember)
                .HasForeignKey<FacultyMember>(fm => fm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Department - Relationship
            builder
                .HasOne(fm => fm.Department)
                .WithMany(d => d.FacultyMembers)
                .HasForeignKey(fm => fm.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Institution - Relationship
            builder
                .HasOne(fm => fm.Institution)
                .WithMany(i => i.FacultyMembers)
                .HasForeignKey(fm => fm.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Course Assignments - Relationship
            builder.HasMany(fm => fm.CourseAssignments).WithOne(ca => ca.FacultyMember);

            // * Attendance - Relationship
            builder.HasMany(fm => fm.Attendances).WithOne(a => a.FacultyMember);
        }
    }
}
