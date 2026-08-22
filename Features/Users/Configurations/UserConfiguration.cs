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
            // * Avatar
            builder.OwnsOne(
                u => u.Avatar,
                avatar =>
                {
                    avatar.Property(a => a.Data).HasColumnType("bytea").HasColumnName("AvatarData");

                    avatar.Property(a => a.ContentType).HasColumnName("AvatarContentType");
                }
            );

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
                .HasColumnName("Role")
                .IsRequired()
                .HasDefaultValue(UserRole.Student);

            // * IsActive
            builder.Property(u => u.IsActive).IsRequired().HasDefaultValue(true);

            // * Refresh Tokens - Relationship
            builder.HasMany(u => u.RefreshTokens).WithOne(rt => rt.User);

            // * Admin - Relationship
            builder.HasOne(u => u.Admin).WithOne(a => a.User);

            // * Faculty Member - Relationship
            builder.HasOne(u => u.FacultyMember).WithOne(fm => fm.User);

            // * Student - Relationship
            builder.HasOne(u => u.Student).WithOne(s => s.User);
        }
    }
}
