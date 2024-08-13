using BookShop.Application.Contracts;
using BookShop.Application.Dto.Chapter;
using BookShop.Application.Mappers;
using BookShop.Domain;
using BookShop.Domain.Models.Chapters;
using BookShop.Domain.Models.Products;

namespace BookShop.Application.Services
{
    public class ChapterService(IUnitOfWork unitOfWork) : IChapterService
    {
        public async Task<ChapterDto> GetChapterById(int chapterId)
        {
            var chapter = await unitOfWork.ChapterRepository.GetChapterById(chapterId);
            var product = await unitOfWork.ProductRepository.GetById(chapter.ProductId);
            return new ChapterDto()
            {
                ProductId = product.Id,
                Title = chapter.Title
            };
        }
        public async Task<IReadOnlyList<ChapterDto>> GetAllChapters()
        {
            var chapterDto = new List<ChapterDto>();
            var allChapteres = await unitOfWork.ChapterRepository.GetAllChapters();
            foreach (var chapter in allChapteres)
            {
                chapterDto.Add(new ChapterDto()
                {
                    Title = chapter.Title,
                    ProductId = chapter.ProductId
                }); ;
            }
            return chapterDto;
        }
        public async Task AddChapter(ChapterDto chapterDto)
        {
            var chapter = ChapterMapper.ChapterDtoToChapter(chapterDto);
            await unitOfWork.ChapterRepository.AddChapter(chapter);
            await unitOfWork.Save();
        }
        public async Task UpdateChapter(UpdateChapterDto dto)
        {
            var chapter = await unitOfWork.ChapterRepository.GetChapterById(dto.ChapterId);
            if (chapter == null) throw new Exception("Please enter valid Id");
            chapter.Title = dto.Title;
            chapter.ProductId = dto.ProductId;
            await unitOfWork.Save();
        }
        public async Task DeleteChapter(int id)
        {
            var chapter = await unitOfWork.ChapterRepository.GetChapterById(id);
            if (chapter == null) throw new Exception("Please enter valid id");
            await unitOfWork.ChapterRepository.DeleteChapter(chapter);
            await unitOfWork.Save();
        }
    }
}
