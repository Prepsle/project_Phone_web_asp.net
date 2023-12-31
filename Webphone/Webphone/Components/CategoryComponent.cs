using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Webphone.Components
{
    [ViewComponent(Name = "Categories")]
    public class CategoryComponent : ViewComponent
    {
        private DataContext _context;

        public CategoryComponent (DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofcategory = (from item in _context.Categories
                                  where (item.IsActive == true)
                                  select item).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofcategory));
            //IsActive == 1 hiện 
            //         == 0 ẩn
        }

    }
}
