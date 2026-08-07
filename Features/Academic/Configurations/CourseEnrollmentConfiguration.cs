using Backend.Features.Academic.Models.CourseEnrollment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class CourseEnrollmentConfiguration : IEntityTypeConfiguration<CourseEnrollment>
    {
        public void Configure(EntityTypeBuilder<CourseEnrollment> builder)
        {
            // * Status
            builder.Property(ce => ce.Status).HasConversion<string>().IsRequired();

            // * Course - Relationship
            builder
                .HasOne(ce => ce.Course)
                .WithMany(c => c.CourseEnrollments)
                .OnDelete(DeleteBehavior.Cascade);

            // * Student - Relationship
            builder
                .HasOne(ce => ce.Student)
                .WithMany(s => s.CourseEnrollments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
