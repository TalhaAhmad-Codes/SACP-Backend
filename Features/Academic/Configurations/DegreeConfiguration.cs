using Backend.Features.Academic.Models.Degrees;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class DegreeConfiguration : IEntityTypeConfiguration<Degree>
    {
        public void Configure(EntityTypeBuilder<Degree> builder)
        {
            // Title
            builder.Property(d => d.Title).HasMaxLength(MaxValue.DegreeTitle).IsRequired();

            // Code
            builder.Property(d => d.Code).HasMaxLength(MaxValue.DegreeCode).IsRequired();

            // Department
            builder
                .HasOne(d => d.Department)
                .WithMany(dt => dt.Degrees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
