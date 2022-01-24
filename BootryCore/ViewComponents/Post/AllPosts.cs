using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Post
{
    public class AllPosts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.GetAllBL());
        }
    }
}
