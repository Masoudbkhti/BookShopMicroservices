namespace BookShop.Domain
{
    public interface ITokenRepository
    {
        string CreateToken(Domain.Models.Users.User user);
    }
}
