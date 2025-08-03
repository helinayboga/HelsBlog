using Microsoft.AspNetCore.Mvc;
using MyBlog.Repositories;
using MyBlog.Models.ViewModels;

namespace MyBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ArtMovements()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("art-movements");
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> ArtworkAnalysis()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("artwork-analysis");
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> DrawingTechniques()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("drawing-techniques");
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> MyDrawings()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("my-drawings");
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> Creativity()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("creativity");
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> Inspirational()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("inspirational");
            return View(blogPosts);
        }

        [HttpGet]
        public async Task<IActionResult> Motivation()
        {
            var blogPosts = await blogPostRepository.GetByCategoryUrlHandleAsync("motivation");
            return View(blogPosts);
        }
    }
} 