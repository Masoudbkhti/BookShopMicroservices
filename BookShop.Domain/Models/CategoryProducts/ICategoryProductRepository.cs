using BookShop.Domain.Models.CategoryProducts;

namespace BookShop.Domain.Models.CategoryProduct
{
    public interface ICategoryProductRepository 
    {
        Task<bool> isExistById(int categoryId, int ProductId);
        Task<List<CategoryProducts.CategoryProduct>> GetCategoriesForProduct(int productId);
    }
}
