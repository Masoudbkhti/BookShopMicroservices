using BookShop.Application.Dto.Category;
using BookShop.Application.Dto.CategoryProduct;

namespace BookShop.Application.Contracts
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task Update(CategoryDto dto);
        Task Delete(int id);
        Task<CategoryDto> Get(int id);
        Task<IReadOnlyList<CategoryDto>> GetAll();
        Task<bool> DupplicatedCategory(string categoryName);
        Task<bool> isExistById(int id);

        Task<Domain.Models.Categories.Category> GetCategoryByName(string name);



    }
}
