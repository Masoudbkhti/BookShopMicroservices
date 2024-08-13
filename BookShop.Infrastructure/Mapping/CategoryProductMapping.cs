using BookShop.Domain.Models.CategoryProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Mapping
{
    public class CategoryProductMapping : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.ToTable("CategoryProduct").HasKey(cp => cp.CpId);
            builder.Property(cp => cp.CategoryId).IsRequired();
            builder.Property(cp => cp.ProductId).IsRequired();
            builder.HasOne(cp => cp.Category).WithMany(c => c.Products).HasForeignKey(cp => cp.CategoryId);
            builder.HasOne(cp => cp.Product).WithMany(p => p.Categories).HasForeignKey(cp => cp.ProductId);
        }
    }
}
