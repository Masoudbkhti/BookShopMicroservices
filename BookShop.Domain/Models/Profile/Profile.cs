using BookShop.Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.Models.Profile;

public class Profile
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int NationalId { get; set; }
    public string Address { get; set; }
    public User User { get; set; }
}