using BookShop.Domain.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category").HasKey(c => c.Id);
            builder.Property(c => c.Title).HasMaxLength(70).IsRequired();
        }
    }
}
