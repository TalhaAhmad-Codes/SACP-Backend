using Backend.Features.Academic.Models.Departments;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Name
            builder.Property(d => d.Name).HasMaxLength(MaxValue.DepartmentName).IsRequired();
            builder.HasIndex(d => d.Name).IsUnique();

            // Description
            builder.Property(d => d.Description).HasMaxLength(MaxValue.Description);

            // Relationship with institution
            builder
                .HasOne(d => d.Institution)
                .WithMany(i => i.Departments)
                .HasForeignKey(d => d.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
