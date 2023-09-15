using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brand");
        builder.Property(p => p.BrandName)
        .HasColumnType("varchar(255) COLLATE utf8mb4_unicode_ci")
        .HasMaxLength(70)
        .IsRequired();
        builder.HasIndex(p => p.BrandName)
        .IsUnique();
    }
}