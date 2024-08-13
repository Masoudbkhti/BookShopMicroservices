namespace BookShop.Domain.Models.Chapters
{
    public interface IChapterRepository
    {
        Task<Chapter> GetChapterByName(string name);
        Task<bool> DupplicatedChapter(string chapterName, int productId);

        Task AddChapter(Chapter chapter);

        Task<Chapter> GetChapterByProductId(int productId);
        Task<Chapter> GetChapterById(int chapterId);

        Task DeleteChapter(Chapter chapter);
        Task<List<Chapter>> GetAllChapters();
    }
}
