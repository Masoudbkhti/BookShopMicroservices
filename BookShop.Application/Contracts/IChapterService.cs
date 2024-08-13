using BookShop.Application.Dto.Chapter;
using BookShop.Domain.Models.Chapters;

namespace BookShop.Application.Contracts
{
    public interface IChapterService
    {
        Task AddChapter(ChapterDto chapterDto);

        Task UpdateChapter(UpdateChapterDto updateChapterDto);

        Task DeleteChapter(int id);

        Task<IReadOnlyList<ChapterDto>> GetAllChapters();

        Task<ChapterDto> GetChapterById(int id);
    }
}
