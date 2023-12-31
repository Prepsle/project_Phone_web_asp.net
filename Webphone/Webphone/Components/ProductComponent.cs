using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Startup.Components
{
    [ViewComponent(Name = "Product")]
    public class ProductComponent : ViewComponent
    {
        private readonly DataContext _context;
        public ProductComponent (DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofProduct = (from p in _context.view_Categories_Products
                              orderby p.ProductID descending
                              select p).Take(8).ToList();
            ViewBag.productcategories = _context.Categories.ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofProduct));
        }
    }
}
