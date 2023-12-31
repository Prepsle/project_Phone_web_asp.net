using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Startup.Components
{
    [ViewComponent(Name = "Blog")]
    public class BlogComponent : ViewComponent
    {
        private readonly DataContext _context;
        public BlogComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.Blogs
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.Blog_Id descending
                              select p).Take(3).ToList();
            ViewBag.blog_Comments = _context.Blog_Comments.ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
