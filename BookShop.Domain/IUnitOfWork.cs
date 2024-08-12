using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Users;

namespace BookShop.Domain;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    IUserRepository UserRepository { get; }
    Task Save();
}