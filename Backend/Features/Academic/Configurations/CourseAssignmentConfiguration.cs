using Backend.Features.Academic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            // * Status
            builder.Property(ca => ca.Status).HasConversion<string>().IsRequired();

            // * Course - Relationship
            builder
                .HasOne(ca => ca.Course)
                .WithOne(c => c.CourseAssignment)
                .HasForeignKey<CourseAssignment>(ca => ca.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // * Course - Relationship
            builder
                .HasOne(ca => ca.FacultyMember)
                .WithMany(fm => fm.CourseAssignments)
                .HasForeignKey(ca => ca.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
