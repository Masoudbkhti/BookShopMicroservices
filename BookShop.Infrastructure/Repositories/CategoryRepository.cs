using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public CategoryRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<bool> DupplicatedCategory(string categoryName)
        {
            return await _dataBaseContext.Categories.AnyAsync(c => c.Title == categoryName);
        }
        public async Task<bool> isExistById(int id)
        {
            return await _dataBaseContext.Categories.AnyAsync(c => c.Id == id);
        }
        public async Task<Category> GetCategoryByName(string name)
        {
            return await _dataBaseContext.Categories.FirstOrDefaultAsync(c => c.Title == name);
        }

        public async Task<Category> Add(Category category)
        {
            var categoryEntry = await _dataBaseContext.Categories.AddAsync(category);
            return categoryEntry.Entity;
        }

        public async Task Delete(Category category)
        {
            _dataBaseContext.Categories.Remove(category);
        }

        public async Task<Category> GetById(int id)
        {
            return await _dataBaseContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return _dataBaseContext.Categories.ToList();
        }
    }
}
