using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Webphone.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuiewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AdminMenuiewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from mn in _context.AdminMenus
                          where (mn.IsActive == true)
                          select mn).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", mnList));

        }
    }
}
