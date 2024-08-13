using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.Chapters;

namespace BookShop.Domain.Models.Products;

public class Product
{
    public  int Id { get; set; }
    public  string SKU { get; set; }
    public  string Title { get; set; }
    public  string? SubTitle { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public IEnumerable<CategoryProducts.CategoryProduct> Categories { get; set; }
    public IEnumerable<Chapter> Chapters { get; set; }



    // public void Update(string title,string subTitle,string description,string sKU)
    // {
    //     Title = title;
    //     SubTitle =subTitle;
    //    Description = description;
    //     SKU = sKU;
    // }
}