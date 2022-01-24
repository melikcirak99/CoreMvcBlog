using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using BootryCore.ViewComponents.Base;
using System.Linq;

namespace BootryCore.ViewComponents.LatestNews
{
    public class GetPostsByCategory : ViewComponent
    {
        public IViewComponentResult Invoke(int categoryId)
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return View(pm.GetPostsByCategory(categoryId).Take(4));
        }
    }
}
