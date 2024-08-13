using BookShop.Domain;
using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.CategoryProduct;
using BookShop.Domain.Models.Chapters;
using BookShop.Domain.Models.Products;
using BookShop.Domain.Models.Profile;
using BookShop.Domain.Models.Users;

namespace BookShop.Infrastructure;


public class UnitOfWork: IUnitOfWork
{
    private readonly DataBaseContext _dbContext;
    public IProductRepository ProductRepository { get; }
    public IUserRepository UserRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IChapterRepository ChapterRepository { get; }
    public IProfileRepository ProfileRepository { get; }
    public ITokenRepository TokenRepository { get; }
    public ICategoryProductRepository CategoryProductRepository { get; }


    public UnitOfWork(DataBaseContext dbContext, IProductRepository productRepository,
        IUserRepository userRepository, ICategoryRepository categoryRepository, 
        ICategoryProductRepository categoryProductRepository, IChapterRepository chapterRepository,
        IProfileRepository profileRepository, ITokenRepository tokenRepository)
    {
        _dbContext = dbContext;
        ProductRepository = productRepository;
        UserRepository = userRepository;
        CategoryRepository = categoryRepository;
        ChapterRepository = chapterRepository;
        ProfileRepository = profileRepository;
        TokenRepository = tokenRepository;
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
