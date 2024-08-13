using BookShop.Application.Dto.Category;
using BookShop.Domain.Models.Categories;

namespace BookShop.Application.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto CategoryToCategoryDto(this Category category) => new CategoryDto()
        {
            Id = category.Id,
            Title = category.Title,
        };

        public static List<CategoryDto> CategoryListToCategoryDtoList(this IEnumerable<Category> categories)
        {
            var categoryDtos = new List<CategoryDto>();
            foreach (var category in categories)
            {
                categoryDtos.Add(CategoryToCategoryDto(category));
            }
            return categoryDtos;
        }

        
    }
}
