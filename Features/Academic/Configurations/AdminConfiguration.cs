using Backend.Features.Academic.Models.Admin;
using Backend.Shared.Common.FixedValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Features.Academic.Configurations
{
    public sealed class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            // * Name
            builder.OwnsOne(
                a => a.Name,
                name =>
                {
                    name.Property(n => n.FirstName)
                        .HasColumnName("FirstName")
                        .HasMaxLength(MaxValue.PersonName)
                        .IsRequired();

                    name.Property(n => n.LastName)
                        .HasColumnName("LastName")
                        .HasMaxLength(MaxValue.PersonName)
                        .IsRequired();
                }
            );

            // * User - Relationship
            builder
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // * Institution - Relationship
            builder
                .HasOne(a => a.Institution)
                .WithOne(i => i.Admin)
                .HasForeignKey<Admin>(a => a.InstitutionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
