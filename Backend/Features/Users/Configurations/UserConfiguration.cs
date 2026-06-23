using Backend.Features.Users.Models;
using Backend.Features.Users.Models.Enums;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Users.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // * Primary key
            builder.HasKey(u => u.Id);

            // * Avatar
            builder.Property(u => u.Avatar).HasColumnType("varbinary(max)");

            // * Username
            builder.Property(u => u.Username).HasMaxLength(MaxValue.Username).IsRequired();

            // * Email
            builder.Property(u => u.Email).HasMaxLength(MaxValue.Email).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();

            // * Password hash
            builder.Property(u => u.PasswordHash).IsRequired();

            // * Role
            builder
                .Property(u => u.Role)
                .HasConversion<string>()
                .IsRequired()
                .HasDefaultValue(UserRole.Student);

            // * IsActive
            builder.Property(u => u.IsActive).IsRequired().HasDefaultValue(true);

            // * Refresh Tokens - Relationship
            builder.HasMany(u => u.RefreshTokens).WithOne(rt => rt.User);
        }
    }
}
