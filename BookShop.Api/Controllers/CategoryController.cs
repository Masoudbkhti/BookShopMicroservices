using BookShop.Application.Contracts;
using BookShop.Application.Dto.Category;
using BookShop.Domain.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto category)
        {
            await _categoryService.AddCategoryAsync(category);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto dto)
        {
            await _categoryService.Update(dto);   
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var result = await _categoryService.Get(id);
            return new JsonResult(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryService.GetAll();
            return new JsonResult(result);
        }
    }
}
