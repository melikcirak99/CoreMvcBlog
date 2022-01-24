using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BootryCore.ViewComponents
{
    public class Carousel : ViewComponent
    {
        public IViewComponentResult Invoke(int count)
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.Carousel(count));
        }
    }
}
