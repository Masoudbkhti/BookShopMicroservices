using BookShop.Application.Dto.Category;
using BookShop.Application.Dto.CategoryProduct;
using BookShop.Domain;

namespace BookShop.Application.Contracts
{
    public interface ICategoryProductService
    {
        Task AddCategoryToProduct(int productId, CategoryDto categoryDto);
        Task Delete(int id);
        Task<IReadOnlyList<CategoryProductDto>> GetAll(int productId);
        Task<bool> DupplicatedCategoryProduct(int productId, string categoryName);
    }
}
