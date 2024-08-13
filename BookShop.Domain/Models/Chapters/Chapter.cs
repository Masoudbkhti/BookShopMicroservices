using BookShop.Domain.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Domain.Models.Chapters;

public class Chapter
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}