using BookShop.Domain.Models.Categories;
using BookShop.Domain.Models.Products;

namespace BookShop.Domain.Models.CategoryProducts
{
    public class CategoryProduct
    {
        public int CpId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
