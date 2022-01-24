using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;
using System.Linq;
namespace BootryCore.ViewComponents.Post
{
    public class LatestPost : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            PostManager pm = new ComponentBase().GetPostManager();
            EntityLayer.Concrete.Post post = pm.LatestNews(1).First();
            return View(post);
        }
    }
}
