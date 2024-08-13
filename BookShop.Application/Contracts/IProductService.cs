using BookShop.Application.Dto.Product;
using BookShop.Domain.Models.Products;

namespace BookShop.Application.Contracts;

public interface IProductService
{
    Task AddProduct(AddProductDto dto);
    Task UpdateProduct(UpdateProductDto dto);
    Task DeleteProduct(int id);
    Task<ProductDto> GetProduct(int id);
}