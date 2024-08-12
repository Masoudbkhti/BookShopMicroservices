namespace BookShop.Application.Dto;

public class AddProductDto
{
    public  string Title { get; set; }
    public  string? SubTitle { get; set; }
    public string SKU { get; set; }
    public  string Description { get; set; }
    public int Price { get; set; }
}