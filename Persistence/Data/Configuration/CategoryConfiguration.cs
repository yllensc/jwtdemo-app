using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.Property(p => p.CategoryName)
        .HasColumnType("varchar(255) COLLATE utf8mb4_unicode_ci")
        .HasMaxLength(70)
        .IsRequired();
        builder.HasIndex(p => p.CategoryName)
        .IsUnique();
    }
}