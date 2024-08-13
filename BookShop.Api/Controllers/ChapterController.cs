using BookShop.Application.Contracts;
using BookShop.Application.Dto.Chapter;
using BookShop.Domain.Models.Chapters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _chapterService;
        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetChapter(int id)
        {
            return new JsonResult(await _chapterService.GetChapterById(id));
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return new JsonResult(await _chapterService.GetAllChapters());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddChapter([FromBody] ChapterDto dto)
        {
            await _chapterService.AddChapter(dto);
            return Ok();

        }

        [HttpPut("Update")]

        public async Task<IActionResult> UpdateChapter([FromBody] UpdateChapterDto dto)
        {
            await _chapterService.UpdateChapter(dto);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
        {
            await _chapterService.DeleteChapter(id);
            return Ok();
        }
    }
}
