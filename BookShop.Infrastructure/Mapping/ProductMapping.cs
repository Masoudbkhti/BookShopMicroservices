using BookShop.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Mapping;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product").HasKey(p => p.Id);
        builder.Property(p => p.Title).HasMaxLength(70).IsRequired();
        builder.Property(p => p.SubTitle).HasMaxLength(100).IsRequired(false);
        builder.Property(p => p.Description).HasMaxLength(300).IsRequired();
        builder.Property((p => p.SKU)).IsRequired();
        builder.Property(p => p.Price).IsRequired();
    }
}