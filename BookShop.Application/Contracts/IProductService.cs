using BookShop.Application.Dto;

namespace BookShop.Application.Contracts;

public interface IProductService
{
    Task AddProduct(AddProductDto dto);
    Task UpdateProduct(AddProductDto dto, int id);
    Task DeleteProduct(int id);
}