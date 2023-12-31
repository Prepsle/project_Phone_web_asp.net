using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Webphone.Models;

namespace Webphone.Components
{
    [ViewComponent(Name = "RecentBlog")]
    public class RecentBlogComponent : ViewComponent
    {
        private readonly DataContext _context;
        public RecentBlogComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var listofblog = (from item in _context.Blogs
                              where (item.IsActive == true) && item.Status == 1
                              select item).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofblog));
        }
    }
}
