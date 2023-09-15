using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");
        builder.Property(p => p.ProductName)
        .HasColumnType("varchar(255) COLLATE utf8mb4_unicode_ci")
        .HasMaxLength(70)
        .IsRequired();
        builder.HasIndex(p => p.ProductName)
        .IsUnique();
        builder.Property(p => p.Price)
        .IsRequired();
        builder.Property(p => p.CreatedDate)
        .IsRequired();
        builder.HasOne(b => b.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(b => b.IdBrand)
            .IsRequired();
        builder.HasOne(c => c.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.IdCategory)
            .IsRequired();


    }
}