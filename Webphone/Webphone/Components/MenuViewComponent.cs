using Microsoft.AspNetCore.Mvc;
using Webphone.Models;

namespace Webphone.Components
{
	[ViewComponent(Name = "MenuView")]
	public class MenuViewComponent : ViewComponent
	{
		private DataContext _context;
		public MenuViewComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofmenu = (from item in _context.Menus
							  where (item.IsActive == true) && (item.Position == 1)
							  select item).ToList();
			//position == 1 nằm trên
			//position == 2 nằm dưới
			return await Task.FromResult((IViewComponentResult)View("Default", listofmenu));
		}
	}
}
