using Backend.Features.Academic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            // * Obtained Marks
            builder.Property(er => er.ObtainedMarks).IsRequired();

            // * Status
            builder.Property(er => er.Status).IsRequired();

            // * Student - Relationship
            builder
                .HasOne(er => er.Student)
                .WithMany(s => s.ExamResults)
                .HasForeignKey(er => er.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // * Exam - Relationship
            builder
                .HasOne(er => er.Exam)
                .WithMany(e => e.ExamResults)
                .HasForeignKey(er => er.ExamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
