using BookShop.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataBaseContext _dataBaseContext;
    public ProductRepository(DataBaseContext dataBaseContext) 
    {
        _dataBaseContext = dataBaseContext;
        
    }
    public async Task<Product> AddProduct(Product product)
    {
        var productEntry = await _dataBaseContext.Products.AddAsync(product);
        return productEntry.Entity;
    }

    public async Task<Product?> FindById(int id)
    => await _dataBaseContext.Products.FindAsync(id);

    // public async Task UpdateProduct(Product product)
    // {
    //     _dataBaseContext.Products.Update(product);
    // }

    public async Task DeleteProduct(Product product)
    {
        _dataBaseContext.Products.Remove(product);
    }

    public async Task<Product> GetProductByName(string productName)
    {
        string product = productName.ToLower();
        return await _dataBaseContext.Products.FirstOrDefaultAsync(p => p.Title == product);
    }

    public async Task<Product> GetById(int id)
    {
        return await _dataBaseContext.Products.Include(cp => cp.Categories).FirstOrDefaultAsync(p => p.Id == id);
    }
}