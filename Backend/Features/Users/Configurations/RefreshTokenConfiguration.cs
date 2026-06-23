using Backend.Features.Users.Models;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Users.Configurations
{
    public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // * Primary key
            builder.HasKey(rt => rt.Id);

            // * Token
            builder.Property(rt => rt.Token).IsRequired().HasMaxLength(MaxValue.RefreshToken);
            builder.HasIndex(rt => rt.Token).IsUnique();

            // * Expiry date
            builder.Property(rt => rt.ExpiresAt).IsRequired();

            // * Is Revoked
            builder.Property(rt => rt.IsRevoked).IsRequired().HasDefaultValue(false);

            // * User - Relationship
            builder
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // * Ignore derived properties
            builder.Ignore(x => x.IsExpired);
            builder.Ignore(x => x.IsActive);
        }
    }
}
