
namespace BookShop.Domain.Models.Products;

public interface IProductRepository
{
    Task<Product> AddProduct(Product product);
    Task<Product?> FindById(int id);
    // Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
    Task<Product> GetProductByName(string productName);
    Task<Product> GetById(int id);

}