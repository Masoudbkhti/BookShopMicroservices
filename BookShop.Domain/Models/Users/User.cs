using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Models.Users;

public class User
{
    public int Id { get; set; }
    public Profile.Profile Profile { get; set; }
    public string Mobile { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}   