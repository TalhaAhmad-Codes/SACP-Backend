using Backend.Features.Academic.Models.CourseAssignment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
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
