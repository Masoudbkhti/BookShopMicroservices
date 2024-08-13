using BookShop.Domain.Models.Chapters;
using BookShop.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Mapping
{
    public class ChapterMapping : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("Chapter").HasKey(c => c.Id);
            builder.Property(c => c.Title).HasMaxLength(70).IsRequired();
            builder.Property(c => c.ProductId).IsRequired();
            builder.HasOne<Product>(p => p.Product).WithMany(c => c.Chapters).HasForeignKey(p => p.Id);
        }
    }
}
