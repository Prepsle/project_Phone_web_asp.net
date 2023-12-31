using Microsoft.AspNetCore.Mvc;
using Webphone.Ultilities;

namespace Webphone.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        [Area("Admin")]
        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._UserName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;
            return RedirectToAction("Index", "Home");
        }
    }
}
