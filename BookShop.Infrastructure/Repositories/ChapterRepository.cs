using BookShop.Domain.Models.Chapters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Repositories
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public ChapterRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<Chapter> GetChapterByName(string name)
        {
            return await _dataBaseContext.Chapters.FirstOrDefaultAsync(c => c.Title == name);
        }

        public async Task<bool> DupplicatedChapter(string chapterName, int productId)
        {
            var result = await _dataBaseContext.Chapters.
                AnyAsync(c => c.ProductId == productId && c.Title == chapterName);
            return result;
        }

        public async Task AddChapter(Chapter chapter)
        {
            await _dataBaseContext.Chapters.AddAsync(chapter);
        }

        public async Task DeleteChapter(Chapter chapter)
        {
            _dataBaseContext.Chapters.Remove(chapter);
        }

        public async Task<List<Chapter>> GetAllChapter()
        {
            return await _dataBaseContext.Chapters.ToListAsync();
        }

        public async Task<Chapter> GetChapterByProductId(int productId)
        {
            return await _dataBaseContext.Chapters.FirstOrDefaultAsync(c => c.ProductId == productId);
        }
        public async Task<Chapter> GetChapterById(int chapterId)
        {
            return await _dataBaseContext.Chapters.FirstOrDefaultAsync(c => c.Id == chapterId);
        }

        public async Task<List<Chapter>> GetAllChapters()
        {
            return await _dataBaseContext.Chapters.ToListAsync();
        }

    }
}
