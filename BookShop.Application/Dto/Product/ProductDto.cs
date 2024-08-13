namespace BookShop.Application.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
