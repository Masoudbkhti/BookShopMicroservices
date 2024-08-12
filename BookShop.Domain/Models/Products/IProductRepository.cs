
namespace BookShop.Domain.Models.Products;

public interface IProductRepository
{
    Task AddProduct(Product product);
    Task<Product?> FindById(int id);
    // Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
}