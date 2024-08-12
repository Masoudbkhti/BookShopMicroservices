using BookShop.Domain.Models.Products;

namespace BookShop.Infrastructure.Repositories;

public class ProductRepository:IProductRepository
{
    private readonly DataBaseContext _dataBaseContext;
    public ProductRepository(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }
    public async Task AddProduct(Product product)
    
    {
        await _dataBaseContext.Products.AddAsync(product);
    }

    public async Task<Product?> FindById(int id)
    =>await _dataBaseContext.Products.FindAsync(id);

    // public async Task UpdateProduct(Product product)
    // {
    //     _dataBaseContext.Products.Update(product);
    // }

    public async Task DeleteProduct(Product product)
    {
        _dataBaseContext.Products.Remove(product);
    }


}