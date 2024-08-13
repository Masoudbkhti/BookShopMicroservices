using BookShop.Domain.Models.Products;

namespace BookShop.Domain.Models.Categories
{
    public interface ICategoryRepository
    {
        Task<Category> Add(Category category);
        Task Delete(Category category);
        Task<bool> DupplicatedCategory(string categoryName);
        Task<bool> isExistById(int id);
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetCategoryByName(string name);
    }
}
