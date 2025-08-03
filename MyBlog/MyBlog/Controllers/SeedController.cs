using Microsoft.AspNetCore.Mvc;
using MyBlog.Repositories;
using MyBlog.Models.Domain;

namespace MyBlog.Controllers
{
    public class SeedController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public SeedController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> SeedCategories()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Sanat Akımları",
                    Description = "Sanat tarihinin önemli akımları ve dönemleri",
                    UrlHandle = "art-movements",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Eser Analizleri",
                    Description = "Ünlü sanat eserlerinin detaylı analizleri",
                    UrlHandle = "artwork-analysis",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Çizim Teknikleri",
                    Description = "Çizim ve resim teknikleri hakkında bilgiler",
                    UrlHandle = "drawing-techniques",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Kendi Çizimlerim",
                    Description = "Kişisel çizim ve sanat çalışmaları",
                    UrlHandle = "my-drawings",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Yaratıcılık",
                    Description = "Yaratıcılık ve sanatsal gelişim",
                    UrlHandle = "creativity",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "İlham Verici",
                    Description = "İlham verici hikayeler ve sanatçılar",
                    UrlHandle = "inspirational",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Motivasyon",
                    Description = "Sanat ve yaratıcılık motivasyonu",
                    UrlHandle = "motivation",
                    Visible = true,
                    CreatedDate = DateTime.UtcNow
                }
            };

            foreach (var category in categories)
            {
                await categoryRepository.AddAsync(category);
            }

            return Content("Categories seeded successfully!");
        }
    }
} 