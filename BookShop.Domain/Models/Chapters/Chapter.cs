using BookShop.Domain.Models.Products;

namespace BookShop.Domain.Models.Chapters;

public class Chapter
{
    public int Id { get; set; }
    public string Title { get; set; }

    #region Relations

    public Product Product { get; set; }

    #endregion
}