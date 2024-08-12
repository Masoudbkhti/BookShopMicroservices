using BookShop.Domain.Models.Users;

namespace BookShop.Domain.Models.Profile;

public class Profile
{
    public int Id { get; set; }
    public string Address { get; set; }
    public int NationalId { get; set; }

    #region Relations

    public User User { get; set; }

    #endregion
}