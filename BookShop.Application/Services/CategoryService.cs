using BookShop.Application.Contracts;
using BookShop.Application.Dto.Category;
using BookShop.Application.Mappers;
using BookShop.Domain;

namespace BookShop.Application.Services
{
    public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<bool> DupplicatedCategory(string categoryName)
        {
            return await unitOfWork.CategoryRepository.DupplicatedCategory(categoryName);
        }
        public async Task<bool> isExistById(int id)
        {
            return await unitOfWork.CategoryRepository.isExistById(id);
        }
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            if (string.IsNullOrEmpty(categoryDto.Title)) throw new AppException("اطلاعات وارد شده صحیح نیست");
            int.Parse(categoryDto.Title);
            var category = categoryDto.CategoryDtoToCategory();
            await unitOfWork.CategoryRepository.Add(category);
            await unitOfWork.Save();
        }
        public async Task<Domain.Models.Categories.Category> GetCategoryByName(string name)
        {
            return await unitOfWork.CategoryRepository.GetCategoryByName(name);
        }
        public async Task Update(CategoryDto dto)
        {
            var category = await unitOfWork.CategoryRepository.GetById(dto.Id);
            if (category == null || dto.Id <= 0) throw new Exception("Please enter valid category Id.");
            category.Title = dto.Title;
            await unitOfWork.Save();
        }
        public async Task Delete(int id)
        {
            var category = await unitOfWork.CategoryRepository.GetById(id);
            if (category == null || id <= 0) throw new Exception("Please enter valid category Id.");
            await unitOfWork.CategoryRepository.Delete(category);
            await unitOfWork.Save();
        }
        public async Task<CategoryDto> Get(int id)
        {
            var category = await unitOfWork.CategoryRepository.GetById(id);
            if (category == null || id <= 0) throw new Exception("Please enter valid id");            
            var categoryDto = category.CategoryToCategoryDto();
            return categoryDto;
        }
        public async Task<IReadOnlyList<CategoryDto>> GetAll()
        {
            var categories = await unitOfWork.CategoryRepository.GetAll();
            if (categories == null) throw new Exception();

            return CategoryMapper.CategoryListToCategoryDtoList(categories);
        }
    }
}
