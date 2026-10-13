using Backend.Features.Academic.Models.FacultyMembers;
using Backend.Features.Academic.Models.Students;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Name
            builder.Property(s => s.FirstName).HasMaxLength(MaxValue.PersonName).IsRequired();

            builder.Property(s => s.LastName).HasMaxLength(MaxValue.PersonName).IsRequired();

            // Registration Number
            builder.Property(s => s.RegistrationNumber).IsRequired();
            builder.HasIndex(s => s.RegistrationNumber).IsUnique();

            // User
            builder
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Department
            builder
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Degree
            builder
                .HasOne(s => s.Degree)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DegreeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
