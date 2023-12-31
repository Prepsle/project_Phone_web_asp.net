using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webphone.Models;

namespace Webphone.ViewComponents
{
    [ViewComponent(Name = "Product_D")]
    public class ProductDetailComponent : ViewComponent
    {
        private readonly DataContext _context;

        public ProductDetailComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type)
        {
            var items = _context.Products.Where(m => (bool)m.IsActive);
            if (type > 0)
            {
                items = items.Where(i => i.CategoryID == type);
            }
            return await Task.FromResult<IViewComponentResult>(View(items.OrderByDescending(m => m.ProductID).ToList()));
        }
    }
}

