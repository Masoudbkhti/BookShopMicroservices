using BookShop.Application.Dto;
using BookShop.Application.Dto.Authentication;
using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;

namespace BookShop.Application.Mappers;

public static class ProductMapper
{
    public static Product Factory(this AddProductDto dto) => new ()
    {
        Title = dto.Title,
        SKU = dto.SKU,
        SubTitle = dto.SubTitle,
        Description = dto.Description,
        Price = dto.Price
    };

    public static User RegisterDtoToUser(this RegisterDto dto) => new User()
    {
        Name = dto.Name,
        Password = dto.Password,
        Mobile = dto.Mobile,
        Profile = new Profile()
        {
            Address = dto.Address,
            NationalId = dto.NationalId
        }
    };
}