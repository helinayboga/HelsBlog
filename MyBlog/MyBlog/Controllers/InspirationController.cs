using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class InspirationController : Controller
    {
        public IActionResult Inspirational()
        {
            ViewData["Title"] = "İlham Verici";
            return View();
        }

        public IActionResult Creativity()
        {
            ViewData["Title"] = "Yaratıcılık";
            return View();
        }

        public IActionResult Motivation()
        {
            ViewData["Title"] = "Motivasyon";
            return View();
        }
    }
} 