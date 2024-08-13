using BookShop.Application.Dto.Chapter;
using BookShop.Domain.Models.CategoryProduct;
using BookShop.Domain.Models.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Mappers
{
    public static class ChapterMapper
    {
        public static List<Chapter> ChapterIdsToChapter(List<int> chapterIds)
        {
            var chapters = new List<Chapter>();
            foreach (int id in chapterIds)
            {
                chapters.Add(new Chapter() { Id = id });
            }
            return chapters;
        }

        public static Chapter ChapterDtoToChapter(ChapterDto dto) => new Chapter
        {
            Title = dto.Title,
            ProductId = dto.ProductId,
        };

        public static Chapter UpdateChapter(Chapter dto) => new Chapter
        {
            Title = dto.Title,
            ProductId = dto.ProductId,
        };
    }
}
