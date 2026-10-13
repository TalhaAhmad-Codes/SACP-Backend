using Backend.Features.Academic.Models.FacultyMembers;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class FacultyMemberConfiguration : IEntityTypeConfiguration<FacultyMember>
    {
        public void Configure(EntityTypeBuilder<FacultyMember> builder)
        {
            // Name
            builder.Property(f => f.FirstName).HasMaxLength(MaxValue.PersonName).IsRequired();

            builder.Property(f => f.LastName).HasMaxLength(MaxValue.PersonName).IsRequired();

            // Access Code
            builder.Property(f => f.AccessCode).IsRequired();
            builder.HasIndex(f => f.AccessCode).IsUnique();

            // User
            builder
                .HasOne(f => f.User)
                .WithOne(u => u.FacultyMember)
                .HasForeignKey<FacultyMember>(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Department
            builder
                .HasOne(f => f.Department)
                .WithMany(d => d.FacultyMembers)
                .HasForeignKey(f => f.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
