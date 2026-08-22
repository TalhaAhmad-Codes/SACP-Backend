using Backend.Features.Academic.Models.Institution;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            // * Name
            builder.Property(i => i.Name).HasMaxLength(MaxValue.InstitutionName).IsRequired();

            // * Admin - Relationship
            builder.HasOne(i => i.Admin).WithOne(a => a.Institution);

            // * Department - Relationship
            builder.HasMany(i => i.Departments).WithOne(d => d.Institution);

            // * Faculty Member - Relationship
            builder.HasMany(i => i.FacultyMembers).WithOne(fm => fm.Institution);
        }
    }
}
