using Backend.Features.Academic.Models.Courses;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(MaxValue.CourseTitle).IsRequired();

            builder.Property(c => c.Code).HasMaxLength(MaxValue.CourseCode).IsRequired();
            builder.HasIndex(c => c.Code).IsUnique();

            builder
                .HasOne(c => c.Degree)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DegreeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
