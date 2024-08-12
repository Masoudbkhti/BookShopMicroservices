using BookShop.Application.Contracts;
using BookShop.Application.Dto;
using BookShop.Application.Mappers;
using BookShop.Domain;

namespace BookShop.Application.Services;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task AddProduct(AddProductDto dto)
    {
        var product = dto.Factory();
        await unitOfWork.ProductRepository.AddProduct(product);
        await unitOfWork.Save();
    }

    public async Task UpdateProduct(AddProductDto dto, int id)
    {
        var product = await unitOfWork.ProductRepository.FindById(id);
        if (product == null) throw new Exception();
        // product.Update(dto.Title,dto.SubTitle,dto.Description,dto.SKU);
        product.Title = dto.Title;
        product.SubTitle = dto.SubTitle;
        product.Description = dto.Description;
        product.SKU = dto.SKU;
        await unitOfWork.Save();
    }

    public async Task DeleteProduct(int id)
    {
        var product = await unitOfWork.ProductRepository.FindById(id);
        if (product == null) throw new Exception();
        await unitOfWork.ProductRepository.DeleteProduct(product);
        await unitOfWork.Save();
    }
}