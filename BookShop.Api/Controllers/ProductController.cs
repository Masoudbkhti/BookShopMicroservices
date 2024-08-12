
using BookShop.Application.Contracts;
using BookShop.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPost("Add")]
    [Authorize]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto dto)
    {
        await _productService.AddProduct(dto);
        return Ok();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateProduct([FromBody] AddProductDto dto, int id)
    {
        await _productService.UpdateProduct(dto, id);
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteProduct([FromBody] int id)
    {
        await _productService.DeleteProduct(id);
        return NoContent();
    }
        
}