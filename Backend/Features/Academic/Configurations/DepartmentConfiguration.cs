using Backend.Features.Academic.Models.Department;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // * Name
            builder.Property(d => d.Name).HasMaxLength(MaxValue.DepartmentName).IsRequired();

            // * Label
            builder.Property(d => d.Label).IsRequired();

            // * Institution - Relationship
            builder
                .HasOne(d => d.Institution)
                .WithMany(i => i.Departments)
                .HasForeignKey(d => d.InstitutionId)
                .OnDelete(DeleteBehavior.Restrict);

            // * Faculty Member - Relationship
            builder.HasMany(d => d.FacultyMembers).WithOne(fm => fm.Department);

            // * Students - Relationship
            builder.HasMany(d => d.Students).WithOne(s => s.Department);

            // * Course - Relationship
            builder.HasMany(d => d.Courses).WithOne(c => c.Department);
        }
    }
}
