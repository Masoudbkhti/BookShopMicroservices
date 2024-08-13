namespace BookShop.Application.Dto.Authentication;

public class RegisterDto
{
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public int NationalId { get; set; }
}