using Microsoft.AspNetCore.Mvc;
using MyBlog.Repositories;
using MyBlog.Models.Domain;

namespace MyBlog.Controllers
{
    public class ArtController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;

        public ArtController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> ArtMovements()
        {
            ViewData["Title"] = "Sanat Akımları";
            var posts = await blogPostRepository.GetByCategoryAsync("art-movements");
            return View(posts ?? new List<BlogPost>());
        }

        public async Task<IActionResult> ArtworkAnalysis()
        {
            ViewData["Title"] = "Eser Analizleri";
            var posts = await blogPostRepository.GetByCategoryAsync("artwork-analysis");
            return View(posts ?? new List<BlogPost>());
        }

        public async Task<IActionResult> DrawingTechniques()
        {
            ViewData["Title"] = "Çizim Teknikleri";
            var posts = await blogPostRepository.GetByCategoryAsync("drawing-techniques");
            return View(posts ?? new List<BlogPost>());
        }

        public async Task<IActionResult> MyDrawings()
        {
            ViewData["Title"] = "Kendi Çizimlerim";
            var posts = await blogPostRepository.GetByCategoryAsync("my-drawings");
            return View(posts ?? new List<BlogPost>());
        }
    }
}
