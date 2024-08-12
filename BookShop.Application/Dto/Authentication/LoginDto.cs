namespace BookShop.Application.Dto.Authentication;

public class LoginDto
{
    public string Name { get; set; }
    public string Password { get; set; }

    public enum LoginResult
    {
        Success,
        Error,
        UserNotFound
    }
}