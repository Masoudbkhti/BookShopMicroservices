using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.CategoryProduct;
using BookShop.Domain.Models.Chapters;
using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;

namespace BookShop.Domain;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    IUserRepository UserRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICategoryProductRepository CategoryProductRepository { get; }
    IChapterRepository ChapterRepository { get; }
    IProfileRepository ProfileRepository { get; }
    ITokenRepository TokenRepository { get; }
    Task Save();
}