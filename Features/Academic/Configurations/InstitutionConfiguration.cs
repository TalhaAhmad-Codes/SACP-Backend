using Backend.Features.Academic.Models.Institutions;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            // Name
            builder.Property(i => i.Name).HasMaxLength(MaxValue.InstitutionName);
            builder.HasIndex(i => i.Name).IsUnique();
        }
    }
}
