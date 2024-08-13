namespace BookShop.Application.Dto.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<int> CategoryId { get; set; }

    }
}
