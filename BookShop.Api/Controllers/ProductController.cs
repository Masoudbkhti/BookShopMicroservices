
using BookShop.Application.Contracts;
using BookShop.Application.Dto.Product;
using BookShop.Application.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto dto)
    {
        await _productService.AddProduct(dto);
        return Ok();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto dto)
    {
        await _productService.UpdateProduct(dto);
        return Ok();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        await _productService.DeleteProduct(id);
        return NoContent();
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        var result = await _productService.GetProduct(id);
        return Ok(result);
    }

}