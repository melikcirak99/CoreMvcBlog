using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Post
{
    public class PostByWriter : ViewComponent
    {
        public IViewComponentResult Invoke(int writerId)
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.GetAllBL(x => x.WriterId == writerId));
        }
    }
}
