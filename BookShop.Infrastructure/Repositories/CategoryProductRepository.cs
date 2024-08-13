using BookShop.Domain.Models.CategoryProduct;
using BookShop.Domain.Models.CategoryProducts;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories
{
    public class CategoryProductRepository : ICategoryProductRepository

    {
        private readonly DataBaseContext _dataBaseContext;
        public CategoryProductRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }

        public async Task<bool> isExistById(int categoryId, int ProductId)
        {
            bool result = await _dataBaseContext.CategoryProduct.
                AnyAsync(p => p.ProductId == ProductId && p.CategoryId == categoryId);

            return result;
        }

        public async Task<List<CategoryProduct>> GetCategoriesForProduct(int productId)
        {
            return await _dataBaseContext.CategoryProduct.Where(p => p.ProductId == productId).ToListAsync();
        }
    }
}
