using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Webphone.Components
{
    [ViewComponent(Name = "ReviewProduct")]
    public class ReviewProductComponent : ViewComponent
    {
        private readonly DataContext _context;
        public ReviewProductComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Products
                              where (p.IsActive == true) && (p.Review_Product == true)
                              orderby p.ProductID ascending
                              select p).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
