using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BootryCore.ViewComponents.Base;
using DataAccessLayer.EntityFramework;

namespace BootryCore.ViewComponents.LatestNews
{
    public class LatestNews : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.LatestNews(4));
        }
    }
}
