using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult WhoAmI()
        {
            ViewData["Title"] = "Ben Kimim";
            return View();
        }

        public IActionResult MyJourney()
        {
            ViewData["Title"] = "Yolculuğum";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "İletişim";
            return View();
        }
    }
} 