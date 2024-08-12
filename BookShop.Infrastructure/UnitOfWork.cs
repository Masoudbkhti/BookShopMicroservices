using BookShop.Domain;
using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Users;

namespace BookShop.Infrastructure;


public class UnitOfWork: IUnitOfWork
{
    private readonly DataBaseContext _dbContext;
    public IProductRepository ProductRepository { get; }
    public IUserRepository UserRepository { get; }


    public UnitOfWork(DataBaseContext dbContext, IProductRepository productRepository,
        IUserRepository userRepository)
    {
        _dbContext = dbContext;
        ProductRepository = productRepository;
        UserRepository = userRepository;
    }

    public async Task Save()=>await _dbContext.SaveChangesAsync();
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
