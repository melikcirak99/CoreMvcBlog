using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.LatestNews
{
    public class TrendingNow : ViewComponent
    {
        public IViewComponentResult Invoke(int count)
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.TrendingNow(count));
        }
    }
}
