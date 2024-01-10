using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Webphone.Models;

namespace Webphone.Controllers
{
    public class ContactController : Controller
    {
        private readonly DataContext _context;
        public ContactController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(string name, string phone, string email, string message)
        {
            try
            {
                Contacts contact = new Contacts();
                contact.Names = name;
                contact.Phone = phone;
                contact.Email = email;
                contact.ContactDate = DateTime.Now;
                contact.Message = message;
                _context.Add(contact);
                _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
