using Backend.Features.Academic.Models.Sessions;
using Backend.Shared.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            // Name
            builder.Property(s => s.Name).HasMaxLength(MaxValue.SessionName).IsRequired();
        }
    }
}
