using Backend.Features.Academic.Models.Exam;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            // * Type
            builder.Property(e => e.Type).HasConversion<string>().IsRequired();

            // * Date of Conduct
            builder.Property(e => e.DateOfConduct).IsRequired();

            // * Total Marks
            builder.Property(e => e.TotalMarks).IsRequired();

            // * Course - Relationship
            builder
                .HasOne(e => e.Course)
                .WithMany(c => c.Exams)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // * Exam Result - Relationship
            builder.HasMany(e => e.ExamResults).WithOne(er => er.Exam);
        }
    }
}
