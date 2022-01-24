using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EntityLayer.Concrete;

namespace BootryCore.ViewComponents.Contact
{
    public class ContactNotifications : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string admin = HttpContext.Session.GetString("admin");
            if (admin != null)
            {
                ViewBag.admin = JsonConvert.DeserializeObject<Admin>(admin);
            }
            return View();
        }
    }
}
