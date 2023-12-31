using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webphone.Models;

namespace Webphone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {   
            ViewBag.blog_Comments = _context.Blog_Comments.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/blog-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blog = _context.Blogs
                .FirstOrDefault(m => (m.Blog_Id == id) && (m.IsActive == true));
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blog_Comments = _context.Blog_Comments.ToList();
            return View(blog);
        }

        [Route("/list-{slug}-{id:int}.html", Name = "List")]
        public IActionResult List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = _context.view_Blog_Menus
                .Where(m => (m.Menu_Id == id) && (m.IsActive == true)).OrderByDescending(m => m.Blog_Id)
                .Take(6).ToList();

            if (list == null)
            {
                return NotFound();
            }
            ViewBag.blog_Comments = _context.Blog_Comments.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult Create(int id, string name, string email, string message)
        {
            try
            {
                Blog_Comment comment = new Blog_Comment();
                comment.Blog_Id = id;
                comment.Name = name;
                comment.CreateDate = DateTime.Now;
                comment.Email = email;
                comment.Detail = message;
                _context.Add(comment);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }

        [Route("/product-{slug}-{id:long}.html", Name = "product")]
        public IActionResult Details_product(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _context.Products
                .FirstOrDefault(m => (m.ProductID == id) && (m.IsActive == true));
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.productcategories = _context.Categories.ToList();
            return View(product);
        }

        [Route("/List_p-{slug}-{id:int}.html", Name = "List_product")]
        public IActionResult List_product(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var list = _context.view_Categories_Products
                .Where(m => (m.CategoryID == id) && (m.IsActive == true)).OrderByDescending(m => m.ProductID)
                .Take(12).ToList();
            ViewBag.listproduct = _context.Products.ToList();
            if (list == null)
            {
                return NotFound();
            }

            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}