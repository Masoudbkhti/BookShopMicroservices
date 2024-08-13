using BookShop.Application.Dto.Category;
using BookShop.Application.Dto.CategoryProduct;
using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.CategoryProducts;
using BookShop.Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Mappers
{
    public static class CategoryProductMapper
    {
        public static CategoryProduct Factory(Product product, Category category) => new CategoryProduct()
        {
            CategoryId = category.Id,
            ProductId = product.Id,
        };

        public static CategoryProductDto CategoryProductToCategoryProductDto(this CategoryProduct categoryProduct) 
            => new CategoryProductDto()
            {
            };

        public static List<CategoryProductDto> CategoryProductListToCategoryProductDtoList(List<CategoryProduct> categoryProducts)
        {
            var CategoryProductDtos = new List<CategoryProductDto>();
            foreach (var categoryProduct in categoryProducts)
            {
                CategoryProductDtos.Add(CategoryProductToCategoryProductDto(categoryProduct));
            }
            return CategoryProductDtos;
        }

        public static List<CategoryProduct> CategoryIdsToCategoryProducts(List<int> categoryIds)
        {
            var categoryProducts = new List<CategoryProduct>();
            foreach (int id in categoryIds)
            {
                categoryProducts.Add(new CategoryProduct() { CategoryId = id});
            }
            return categoryProducts;
        }

    }
}
