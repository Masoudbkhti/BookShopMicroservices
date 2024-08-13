/*using BookShop.Application.Contracts;
using BookShop.Application.Dto.Category;
using BookShop.Application.Dto.CategoryProduct;
using BookShop.Application.Mappers;
using BookShop.Domain;

namespace BookShop.Application.Services
{
    public class CategoryProductService(IUnitOfWork unitOfWork) : ICategoryProductService
    {

        public async Task<AddCategoryResult> AddCategoryToProduct(int productId, CategoryDto categoryDto)
        {
            string categoryName = categoryDto.Title.ToLower();
            var product = await unitOfWork.ProductRepository.GetById(productId);
            var category = await unitOfWork.CategoryRepository.GetCategoryByName(categoryName);
            if (category == null || product == null)
            {
                return AddCategoryResult.NotFound;
            }
            if (await DupplicatedCategoryProduct(product.Id, category.Title))
            {
                return AddCategoryResult.DupplicatedCategoryProduct;
            }
            var categoryProduct = CategoryProductMapper.Factory(product, category);
            await unitOfWork.CategoryProductRepository.Add(categoryProduct);

            return AddCategoryResult.Success;
        }

        public async Task<AddCategoryResult> Delete(int id)
        {
            if (id <= 0)
            {
                return AddCategoryResult.Error;
            }
            var categoryProduct = await unitOfWork.CategoryProductRepository.Get(id);
            if (categoryProduct == null)
            {
                return AddCategoryResult.NotFound;
            }
            await unitOfWork.CategoryProductRepository.Delete(categoryProduct);
            await unitOfWork.Save();
            return AddCategoryResult.Success;

        }
        public async Task<IReadOnlyList<CategoryProductDto>> GetAll(int productId)
        {
            if (productId <= 0)
            {
                return null;
            }
            var categoryProducts = await unitOfWork.CategoryProductRepository.GetCategoriesForProduct(productId);
            if (categoryProducts == null)
            {
                return null;
            }
            return CategoryProductMapper.CategoryProductListToCategoryProductDtoList(categoryProducts);
        }

        public async Task<bool> DupplicatedCategoryProduct(int productId, string categoryName)
        {
            string name = categoryName.ToLower();
            var product = await unitOfWork.ProductRepository.GetById(productId);
            var category = await unitOfWork.CategoryRepository.GetCategoryByName(name);
            if (product == null && category == null)
            {
                return false;
            }

            return await unitOfWork.CategoryProductRepository.isExistById(product.Id, category.Id);
        }

    }
}
*/