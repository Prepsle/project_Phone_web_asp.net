using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Webphone.Components
{
    [ViewComponent(Name = "ImageBanner")]
    public class ImageComponent : ViewComponent
    {
        private DataContext _context;

        public ImageComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofcategory = (from item in _context.Images
                                  select item).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofcategory));
            //IsActive == 1 hiện 
            //         == 0 ẩn
        }
    }
}
