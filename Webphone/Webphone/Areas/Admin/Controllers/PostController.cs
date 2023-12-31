using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webphone.Models;
using Webphone.Ultilities;

namespace Webphone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;
        public PostController(DataContext context) 
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            var mnList = _context.Blogs.OrderBy(m => m.Blog_Id).ToList();
            return View(mnList);
        }

        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.Menu_Name,
                              Value = m.Menu_Id.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text= "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                _context.SaveChanges();
            }
            return RedirectToAction("Create");
        }

        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var po = _context.Blogs.Find(id);
            if (po == null)
            {
                return NotFound();
            }

            var polist = (from m in _context.Blogs
                          select new SelectListItem()
                          {
                              Text = m.Title,
                              Value = m.Blog_Id.ToString(),
                          }).ToList();
            polist.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.poList = polist;
            return View(po);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog po)
        {
            if (ModelState.IsValid)
            {
                _context.Blogs.Update(po);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(po);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bl = _context.Blogs.Find(id);
            if (bl == null)
            {
                return NotFound();
            }
            return View(bl);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var delePost = _context.Blogs.Find(id);
            if (delePost == null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(delePost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
