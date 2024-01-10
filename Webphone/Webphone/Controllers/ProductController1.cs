using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webphone.Models;

namespace Webphone.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
