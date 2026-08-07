using Backend.Features.Academic.Models.Lecture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class LectureConfiguration : IEntityTypeConfiguration<Lecture>
    {
        public void Configure(EntityTypeBuilder<Lecture> builder)
        {
            // * Start Time
            builder.Property(l => l.StartTime).IsRequired();

            // * End Time
            builder.Property(l => l.EndTime).IsRequired();

            // * Course Assignment - Relationship
            builder
                .HasOne(l => l.Course)
                .WithOne(c => c.Lecture)
                .HasForeignKey<Lecture>(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
