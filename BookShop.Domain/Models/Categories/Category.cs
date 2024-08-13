

namespace BookShop.Domain.Models.Categories;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; }

    public IEnumerable<CategoryProducts.CategoryProduct> Products { get; set; }

}