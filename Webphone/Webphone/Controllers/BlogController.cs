using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webphone.Models;

namespace Webphone.Controllers
{
    public class BlogController : Controller
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.blog_Comments = _context.Blog_Comments.ToList();
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
    }
}
