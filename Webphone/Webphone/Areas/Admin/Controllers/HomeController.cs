using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webphone.Models;
using Webphone.Ultilities;

namespace Webphone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            ViewBag.Products = _context.Products.ToList();
            ViewBag.Blog = _context.Blogs.ToList();
            return View();
        }
    }
}

