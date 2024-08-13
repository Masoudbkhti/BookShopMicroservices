using BookShop.Application.Dto.Authentication;
using BookShop.Application.Dto.Category;
using BookShop.Application.Dto.Product;
using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.CategoryProduct;
using BookShop.Domain.Models.Chapters;
using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;
using BookShop.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static BookShop.Application.Dto.Category.CategoryDto;

namespace BookShop.Application.Mappers;

public static class ProductMapper
{
    public static Product Factory(this AddProductDto dto) => new ()
    {
        Title = dto.Title,
        SKU = dto.SKU,
        SubTitle = dto.SubTitle,
        Description = dto.Description,
        Price = dto.Price,
        Categories = CategoryProductMapper.CategoryIdsToCategoryProducts(dto.CategoryId),
    };

    public static ProductDto ProductToProductDto(this Product product) => new()
    {
        Id = product.Id,
        Title = product.Title,
        SKU = product.SKU,
        SubTitle = product.SubTitle,
        Description = product.Description,
        Price = product.Price,
        CategoryIds = product.Categories.Where(p => p.ProductId == product.Id).Select(c => c.CategoryId)
    };

    public static User RegisterDtoToUser(this RegisterDto dto) => new User()
    {
        Name = dto.Name,
        Password = dto.Password,
        Mobile = dto.Mobile,
        Profile = new Profile()
        {
            UserName = dto.Name,
            Address = dto.Address,
            NationalId = dto.NationalId
        },
    };

    public static Category CategoryDtoToCategory(this CategoryDto categoryDto) => new Category()
    {
        Title = categoryDto.Title,
    };
}