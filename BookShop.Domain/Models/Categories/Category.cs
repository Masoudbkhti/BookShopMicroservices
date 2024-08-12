using BookShop.Domain.Models.Products;

namespace BookShop.Domain.Models.Categories;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }

    #region Relations

    public List<Product> Products { get; set; }

    #endregion
}