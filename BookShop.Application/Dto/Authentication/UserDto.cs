namespace BookShop.Application.Dto.Authentication;

public class UserDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int NationalId { get; set; }
    public string Token { get; set; }
}