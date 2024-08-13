using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.CategoryProducts;
using BookShop.Domain.Models.Chapters;
using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;
using BookShop.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure;

public class DataBaseContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<CategoryProduct> CategoryProduct { get; set; }
    
    
    public DataBaseContext(DbContextOptions options) : base(options)
    {
      
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryProductMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChapterMapping).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfileMapping).Assembly);
        modelBuilder.Entity<Product>().HasData(new Product()
        {
            Id = 1,
            Title = "Penaut Butter",
            SubTitle = "30Nuss organic Penaut Butter",
            Description = "Best penaut butter",
            Price = 59000,
            SKU = "penut1001"
        });
    }
}