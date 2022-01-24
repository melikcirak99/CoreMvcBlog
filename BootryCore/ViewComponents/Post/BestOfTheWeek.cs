using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Post
{
    public class BestOfTheWeek : ViewComponent
    {
        public IViewComponentResult Invoke(int count)
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.BestOfTheWeek(count));
        }
    }
}
