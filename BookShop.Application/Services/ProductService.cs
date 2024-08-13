using BookShop.Application.Contracts;
using BookShop.Application.Dto.Product;
using BookShop.Application.Mappers;
using BookShop.Domain;
using BookShop.Domain.Models.Products;

namespace BookShop.Application.Services;

public class ProductService(IUnitOfWork unitOfWork) : IProductService
{
    public async Task AddProduct(AddProductDto dto)
    {
        foreach (var id in dto.CategoryId)
        {
            if (!await unitOfWork.CategoryRepository.isExistById(id))
            {
                throw new Exception("please enter valid category id.");
            }
        }
        var product = dto.Factory();
        await unitOfWork.ProductRepository.AddProduct(product);
        await unitOfWork.Save();
    }
    public async Task UpdateProduct(UpdateProductDto dto)
    {
        var product = await unitOfWork.ProductRepository.FindById(dto.Id);
        if (product == null) throw new Exception("Please enter valid product id.");
        foreach (var id in dto.CategoryId)
        {
            if (await unitOfWork.CategoryProductRepository.isExistById(id,product.Id))
            {
                throw new Exception("please enter valid new category id.");
            }
        }
        // product.Update(dto.Title,dto.SubTitle,dto.Description,dto.SKU);
        product.Title = dto.Title;
        product.SubTitle = dto.SubTitle;
        product.Description = dto.Description;
        product.SKU = dto.SKU;
        product.Categories = CategoryProductMapper.CategoryIdsToCategoryProducts(dto.CategoryId);
        await unitOfWork.Save();
    }
    public async Task DeleteProduct(int id)
    {
        var product = await unitOfWork.ProductRepository.FindById(id);
        if (product == null) throw new Exception();
        await unitOfWork.ProductRepository.DeleteProduct(product);
        await unitOfWork.Save();
    }
    public async Task<ProductDto> GetProduct(int id)
    {
        var product =  await unitOfWork.ProductRepository.GetById(id);   
        if (product == null) throw new Exception();
        return ProductMapper.ProductToProductDto(product);
    }
}