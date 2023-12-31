using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Startup.Components
{
    [ViewComponent(Name = "LatestProduct")]
    public class LatestProductComponent : ViewComponent
    {
        private readonly DataContext _context;
        public LatestProductComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Products
                              where (p.IsActive == true) && (p.Latest_Product == true)
                              orderby p.ProductID ascending
                              select p).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
